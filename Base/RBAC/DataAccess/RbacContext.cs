using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Wings.Base.RBAC.Entity;

namespace Wings.Base.RBAC.DataAccess
{

    /// <summary>
    /// 基于角色权限系统
    /// </summary>
    public class RbacContext : DbContext
    {

        /// <summary>
        ///  
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public RbacContext(DbContextOptions<RbacContext> options) : base(options) { }
        /// <summary>
        /// 用户
        /// </summary>
        public DbSet<RbacUser> rbacUsers { get; set; }

    }

}