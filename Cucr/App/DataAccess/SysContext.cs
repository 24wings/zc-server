using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.Entity.Sys;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.App.DataAccess {

    /// <summary>
    /// OA数据访问
    /// </summary>
    public class SysContext : DbContext {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public SysContext (DbContextOptions<SysContext> options) : base (options) { }
        /// <summary>
        /// 问卷调查
        /// </summary>
        public DbSet<User> users { get; set; }
    }

}