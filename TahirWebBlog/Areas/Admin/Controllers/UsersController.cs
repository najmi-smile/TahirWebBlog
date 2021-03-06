﻿using static TahirWebBlog.Areas.Admin.Models.UserModel;
using Microsoft.AspNetCore.Mvc;
using TahirWebBlogDbContext;
using TahirWebBlogEntities;

namespace TahirWebBlog.Areas.Admin.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/users")]
    public class UsersController : Controller
    {
        private AppDatabase Db { get; set; }

        public UsersController(AppDatabase _db)
        {
            Db = _db;
        }

        [HttpGet]
        [Route ("")]
        public string GetUsers()
        {
            return "Admin/User";
        }
        [HttpGet]
        [Route("{id}")]
        public string GetUser(int id)
        {
            return "User by id";
        }

        [HttpPost]
        [Route("")]
        public bool SaveUser(NewUser formUser)
        {
            //var u = Db.Users.Where(u => u.UserName == formUser.UserName);
            //if (u != null)
            //    ModelState.AddModelError("UserName", "Username must be unique!");
            
            if(!ModelState.IsValid)
                return false;
           
            var user = new User()
            {
                UserName = formUser.UserName,
                Email = formUser.Email
            };
            user.SetPassword(formUser.Password);

            Db.Add<User>(user);
            Db.SaveChanges();
            return true;
        }

        [HttpPut]
        [Route("{id}")]
        public bool UpdateUser(int id, EditUser formUser)
        {
            return true;
        }

        [HttpPut]
        [Route("reset_password")]
        public bool ResetPassword(int id, EditUser formUser)
        {
            return true;
        }

        [HttpDelete]
        [Route("{id}")]
        public bool DeleteUser(int id)
        {
            return true;
        }
    }
}