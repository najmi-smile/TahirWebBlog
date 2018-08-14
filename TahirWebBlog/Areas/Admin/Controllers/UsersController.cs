using Microsoft.AspNetCore.Mvc;
using TahirWebBlogDbContext;

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;
using System;


namespace TahirWebBlog.Areas.Admin.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/[controller]")]
    public class UsersController : Controller
    {
        private Database db;
        public UsersController(Database _db)
        {
            db = _db;
        }

        [HttpGet]
        public string Index()
        {
            return "Admin/User";
        }
    }
}