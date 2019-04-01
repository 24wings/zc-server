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
        /// 用户
        /// </summary>
        public DbSet<User> users { get; set; }
        /// <summary>
        /// 发送短信记录表
        /// </summary>
        /// <value></value>
        public DbSet<Message> messages { get; set; }

    }

}