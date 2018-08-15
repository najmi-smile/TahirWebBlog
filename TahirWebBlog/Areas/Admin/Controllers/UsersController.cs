﻿using Microsoft.AspNetCore.Mvc;
using TahirWebBlogDbContext;

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;
using System;
using static TahirWebBlog.Areas.Admin.Models.UserModel;
using TahirWebBlogEntities;

namespace TahirWebBlog.Areas.Admin.Controllers
{
    [Produces("application/json")]
    [Route("api/admin/users")]
    public class UsersController : Controller
    {
        private Database Db { get; set; }

        public UsersController(Database _db)
        {
            Db = _db;
        }

        [HttpGet]
        [Route ("")]
        public string Get()
        {
            return "Admin/User";
        }
        [HttpGet]
        [Route("{id}")]
        public string Get(int id)
        {
            return "User by id";
        }

        [HttpPost]
        [Route("new")]
        public bool New(NewUser formUser)
        {
            if(Db.Users.Any(u => u.UserName == formUser.UserName))
                ModelState.AddModelError("UserName", "Username must be unique!");
            
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
        [Route("edit")]
        public bool Edit(int id, EditUser formUser)
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
        [Route("delete")]
        public bool Delete(int id)
        {
            return true;
        }
    }
}