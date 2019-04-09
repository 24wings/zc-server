using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wings.Base.Common.Attrivute;
using Wings.Base.Common.DTO;
using Wings.DataAccess;

namespace Wings.Base.RBAC.Controllers {
    [Route ("/api/RBAC/Demo")]
    public class DemoController {
        private WingsContext rbac { get; set; }
        public DemoController (WingsContext _rbac) { rbac = _rbac; }

        [HttpGet]

        public object list () {
            var type = Assembly.GetEntryAssembly ().GetType ("Wings.Base.RBAC.DVO.UserDVO");
            Console.WriteLine (type.IsClass);
            var query = type.GetMethod ("query");
            if (query != null) {
                var data = query.Invoke (null, new object[] { this.rbac });
                Console.WriteLine (data);
                return data;
            } else {
                return null;
            }

        }

        /// <summary>
        /// dvo视图
        /// </summary>
        /// <param name="dvo"></param>
        /// <returns></returns>
        [HttpGet ("[action]")]
        public View dvoView (string dvo) {
            var type = Assembly.GetEntryAssembly ().GetType (dvo);
            if (type != null) {
                var viewAttr = (ViewAttribute) type.GetCustomAttribute (typeof (ViewAttribute));
                var memberInfos = type.GetMembers ();
                var cols = new List<Col> ();
                var items = new List<Item> ();

                foreach (var m in memberInfos) {
                    var colAttr = (ColAttribute) m.GetCustomAttribute (typeof (ColAttribute));

                    if (colAttr != null) {
                        var col = new Col ();
                        col.label = colAttr.label;
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

                var view = new View ();
                view.viewType = viewAttr.viewType;
                view.title = viewAttr.title;
                view.cols = cols;
                view.items = items;
                return view;
            } else {
                return null;
            }
        }
    }
}