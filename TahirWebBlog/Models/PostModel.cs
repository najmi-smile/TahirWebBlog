using System.Collections.Generic;
using TahirWebBlogEntities;

namespace TahirWebBlog.Models
{
    public class PostModel
    {
        public List<Article> Articles { get; set; }
        public string Image { get; set; }
    }
}
