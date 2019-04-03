using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cucr.CucrSaas.ZC.Entity.Clzc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.ZC.DataAccess
{

    /// <summary>
    /// OA数据访问
    /// </summary>
    public class ClzcContext : DbContext
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public ClzcContext(DbContextOptions<ClzcContext> options) : base(options) { }
        /// <summary>
        /// 问卷调查
        /// </summary>
        public DbSet<Company> companys { get; set; }
        /// <summary>
        /// 项目经理申请记录
        /// </summary>
        /// <value></value>
        public DbSet<ProjectManageApply> projectManageApplys { get; set; }
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <value></value>
        public DbSet<Role> roles { get; set; }
        /// <summary>
        /// 用户
        /// </summary>
        /// <value></value>
        public DbSet<User> users { get; set; }
        /// <summary>
        /// 银行卡
        /// </summary>
        /// <value></value>
        public DbSet<BankCard> bankCards { get; set; }

    }

}