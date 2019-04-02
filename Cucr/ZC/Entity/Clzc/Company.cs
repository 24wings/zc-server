using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Cucr.CucrSaas.App.Entity.OA;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Cucr.CucrSaas.ZC.Entity.Clzc
{

    /// <summary>
    /// 公司表
    /// </summary>
    [Table("clzc_company")]
    public class Company : BaseEntity
    {
        /// <summary>
        /// 公司Id
        /// </summary>
        /// <value></value>
        public string id { get; set; }
        public string name { get; set; }

        public string account { get; set; }
        ///password, capital, area, address, legalPerson, phone, telephone, license, business, registerDate
    }
}