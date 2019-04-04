using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.ZC.DataAccess {

    /// <summary>
    /// OA数据访问
    /// </summary>
    public class ZCSysContext : DbContext {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public ZCSysContext (DbContextOptions<ZCSysContext> options) : base (options) { }

    }

}