using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.Entity.OA;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.App.DataAccess {

    /// <summary>
    /// OA数据访问
    /// </summary>
    public class OAContext : DbContext {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public OAContext (DbContextOptions<OAContext> options) : base (options) { }
        /// <summary>
        /// 问卷调查
        /// </summary>
        public DbSet<Anwser> anwsers { get; set; }
        /// <summary>
        /// 工作报告
        /// </summary>
        /// <value></value>
        public DbSet<WorkReport> workreports { get; set; }
        /// <summary>
        /// 出勤记录
        /// </summary>
        /// <value></value>
        public DbSet<Incard> incards { get; set; }

        /// <summary>
        /// 工资条
        /// </summary>
        /// <value></value>
        public DbSet<Wages> wageses { get; set; }
    }

}