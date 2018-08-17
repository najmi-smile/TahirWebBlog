using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TahirWebBlogEntities;

namespace TahirWebBlog.Models
{
    public class PostModel
    {
        public List<Article> Articles { get; set; }
        public string Image { get; set; }
    }
}
