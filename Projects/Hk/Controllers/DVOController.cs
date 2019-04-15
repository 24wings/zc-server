using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Wings.Base.Common.Attrivute;
using Wings.Base.Common.DTO;
using Wings.DataAccess;

namespace Wings.Projects.Hk.Controllers {
    /// <summary>
    /// 自动化管理控制器
    /// </summary>
    [Route ("/api/Hk/DVO")]
    public class DVOController {

        private HkContext hk { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="_hk"></param>
        public DVOController (HkContext _hk) { hk = _hk; }

        /// <summary>
        /// dvo查询
        /// </summary>
        /// <param name="dvoFullName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        [HttpGet ("[action]/{dvoFullName}")]
        public object load ([FromRoute] string dvoFullName, [FromQuery] DataSourceLoadOptionsBase options) {
            var type = Assembly.GetEntryAssembly ().GetType (dvoFullName);
            var dbSetMethodInfo = typeof (DbContext).GetMethod ("Set");
            dynamic dbSet = dbSetMethodInfo.MakeGenericMethod (type).Invoke (hk, null);
            dynamic Rec = Activator.CreateInstance (type);
            var data = DataSourceLoader.Load (((Microsoft.EntityFrameworkCore.Internal.InternalDbSet<Wings.Projects.Hk.DVO.Rbac.OrgManage>) dbSet), options);
            return data;
        }

        /// <summary>
        /// 插入数据
        /// </summary>
        /// <param name="dvoFullName"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost ("[action]/{dvoFullName}")]

        public object insert ([FromRoute] string dvoFullName, [FromForm] DevExtremInput input) {
            var type = Assembly.GetEntryAssembly ().GetType (dvoFullName);
            var dbSetMethodInfo = typeof (DbContext).GetMethod ("Set");

            dynamic dbSet = dbSetMethodInfo.MakeGenericMethod (type).Invoke (this.hk, null);
            dynamic instance = Activator.CreateInstance (type);
            JsonConvert.PopulateObject (input.values, instance);
            //Validate(order);
            // if (!ModelState.IsValid)
            // return false;
            // this.hk.orgManage.Add (user);
            dbSet.Add (instance);
            hk.SaveChanges ();

            return instance;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="dvoFullName"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpDelete ("[action]/{dvoFullName}")]
        public object remove ([FromRoute] string dvoFullName, [FromForm] DevExtremInput input) {
            var type = Assembly.GetEntryAssembly ().GetType (dvoFullName);
            var dbSetMethodInfo = typeof (DbContext).GetMethod ("Set");

            dynamic dbSet = dbSetMethodInfo.MakeGenericMethod (type).Invoke (this.hk, null);
            var item = ((Microsoft.EntityFrameworkCore.Internal.InternalDbSet<Wings.Projects.Hk.DVO.Rbac.OrgManage>) dbSet).Find (input.key);
            dbSet.Remove (item);
            hk.SaveChanges ();
            return true;
        }

        /// <summary>
        /// 列出DVO
        /// </summary>
        /// <returns></returns>
        [HttpGet ("[action]")]
        public List<View> listDVO () {
            var _namespace_ = "Wings.Projects.Hk";
            var dvos = Assembly.GetExecutingAssembly ().GetTypes ().Where (t => t.GetCustomAttribute (typeof (TableAttribute)) != null && t.Namespace.StartsWith (_namespace_)).ToArray ();
            var views = new List<View> ();
            foreach (var dvo in dvos) {
                var view = this.getViewByDVO (dvo.FullName);
                views.Add (view);
            }
            return views;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dvo"></param>
        /// <returns></returns>
        public View getViewByDVO (string dvo) {
            var type = Assembly.GetEntryAssembly ().GetType (dvo);
            if (type != null) {
                var view = this.getViewByType (type);
                var memberInfos = type.GetMembers ();
                var cols = new List<Col> ();
                var items = new List<Item> ();
                foreach (var m in memberInfos) {
                    var colAttr = (ColAttribute) m.GetCustomAttribute (typeof (ColAttribute));
                    if (colAttr != null) {
                        var col = new Col ();
                        col.caption = colAttr.caption;
                        col.dataField = colAttr.dataField != null? colAttr.dataField : m.Name;
                        col.dataType = colAttr.dataType.ToString ();
                        cols.Add (col);
                    }
                    var itemAttr = (ItemAttribute) m.GetCustomAttribute (typeof (ItemAttribute));
                    if (itemAttr != null) {
                        var item = new Item ();
                        item.editorType = itemAttr.editorType.ToString ();
                        item.label = new Label { text = itemAttr.label };
                        item.dataField = itemAttr.dataField == null? m.Name : itemAttr.dataField;
                        items.Add (item);
                    }

                }

                view.cols = cols;
                view.items = items;
                return view;
            } else {
                return null;
            }

        }
        /// <summary>
        /// 根据类型获取视图
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public View getViewByType (Type type) {
            var view = new View ();
            var viewAttr = (ViewAttribute) type.GetCustomAttribute (typeof (ViewAttribute));
            view.viewType = viewAttr.viewType.ToString ();
            view.title = viewAttr.title;
            view.fullName = type.FullName;
            var treeViewAttr = (TreeListViewAttribute) type.GetCustomAttribute (typeof (TreeListViewAttribute));
            view.dvo = type.Name;
            if (treeViewAttr != null) {
                view.keyExpr = treeViewAttr.keyExpr;
                view.parentIdExpr = treeViewAttr.parentIdExpr;
                view.viewType = treeViewAttr.viewType.ToString ();
            }
            var dataSourceAttribute = (DataSourceAttribute) type.GetCustomAttribute (typeof (DataSourceAttribute));
            var dataSource = new DataSource ();
            dataSource.url = dataSourceAttribute.url;
            dataSource.insertUrl = dataSourceAttribute.insertUrl == null?dataSourceAttribute.url + "/insert/" + view.fullName : dataSourceAttribute.insertUrl;
            dataSource.loadUrl = dataSourceAttribute.loadUrl == null?dataSourceAttribute.url + "/load/" + view.fullName : dataSourceAttribute.loadUrl;
            dataSource.deleteUrl = dataSourceAttribute.deleteUrl == null?dataSourceAttribute.url + "/remove/" + view.fullName : dataSourceAttribute.deleteUrl;
            dataSource.updateUrl = dataSourceAttribute.updateUrl == null?dataSourceAttribute.url + "/update/" + view.fullName : dataSourceAttribute.updateUrl;
            view.dataSource = dataSource;
            return view;

        }

    }
}