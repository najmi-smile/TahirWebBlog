using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TahirWebBlogDbContext;
using TahirWebBlogEntities;
using TahirWebBlog.Models;
using System.Linq;


namespace TahirWebBlog.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private AppDatabase Db { get; set; }
        public PostsController(AppDatabase db) { Db = db; }

        [HttpGet]
        [Route("")]
        public List<Article> GetPosts()
        {
            List<Article> articles = Db.Articles.ToList();
            return articles;
        }
        [HttpGet]
        [Route("{id}")]
        public Article GetPost(int id)
        {
            var article = Db.Articles.Where(a => a.ArticleId == id).SingleOrDefault();
           
            return new Article()
            {
                ArticleId = article.ArticleId,
                ArticleTitle = article.ArticleTitle                
            };
        }
        [HttpPost]
        [Route("")]
        public bool SavePost(PostModel post)
        {
            return true;
        }

        [HttpPut]
        [Route("{id}")]
        public bool UpDatePost(PostModel post)
        { 
            return true;
        }
        [HttpDelete]
        [Route("{id}")]
        public bool DeletePost(int id)
        {
            return true;
        }
    }
}