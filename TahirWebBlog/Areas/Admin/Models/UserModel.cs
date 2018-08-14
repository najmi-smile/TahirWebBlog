﻿using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TahirWebBlog.Areas.Admin.Models
{
    public class UserModel
    {
        public class NewUser
        {
            [Required, MaxLength(128)]
            public string UserName { get; set; }
            [Required, DataType(DataType.EmailAddress)]
            public string Email { get; set; }
            [Required, DataType(DataType.Password)]
            public string Password { get; set; }
        }
        public class EditUser
        {
            [Required, MaxLength(128)]
            public string UserName { get; set; }
            [Required, DataType(DataType.EmailAddress)]
            public string Email { get; set; }
        }
        public class ResetUserPassword
        {
            public string UserName { get; set; }
            [Required, DataType(DataType.Password)]
            public string Password { get; set; }
        }
    }
}
