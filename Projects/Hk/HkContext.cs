using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Wings.Projects.Hk.DVO.Rbac;

namespace Wings.Projects.Hk {
    /// <summary>
    /// 航空数据环境
    /// </summary>
    public partial class HkContext : DbContext {
        public HkContext () { }

        public HkContext (DbContextOptions<HkContext> options) : base (options) { }

        public virtual DbSet<OrgManage> orgManage { get; set; }

        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder) {

        }
        /// <summary>
        /// 数据库实体创建时
        /// 1.null 扫描Wings.Hk 命名空间下的所有表
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            var _namespace_ = "Wings.Projects.Hk";
            var dvos = Assembly.GetExecutingAssembly ().GetTypes ().Where (t => t.GetCustomAttribute (typeof (TableAttribute)) != null && t.Namespace.StartsWith (_namespace_)).ToArray ();
            // код динамически добавляет 
            Type[] paramTypes = dvos;
            foreach (Type type in paramTypes) {
                if (type.IsClass) {

                    var method = modelBuilder.GetType ().GetMethod ("Entity", new Type[] { });
                    method = method.MakeGenericMethod (new Type[] { type });
                    method.Invoke (modelBuilder, null);
                }
            }

            base.OnModelCreating (modelBuilder);
        }
    }

}