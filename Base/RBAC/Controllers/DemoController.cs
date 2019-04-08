using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Wings.DataAccess;

namespace Wings.Base.RBAC.Controllers {
    [Route ("/api/RBAC/Demo")]
    public class DemoController {
        private WingsContext rbac { get; set; }
        public DemoController (WingsContext _rbac) { rbac = _rbac; }

        [HttpGet]

        public object list () {
            return this.rbac.User.Include (u => u.orderNo).ToArray ();
        }
    }
}