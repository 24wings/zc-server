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

    }

}