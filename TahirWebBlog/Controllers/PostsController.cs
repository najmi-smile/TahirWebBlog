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
        [Route("new")]
        public bool SavePost(PostModel post)
        {
            return true;
        }

        [HttpPut]
        [Route("update_post")]
        public bool UpDatePost(PostModel post)
        { 
            return true;
        }
        [HttpDelete]
        [Route("delete_post")]
        public bool DeletePost(int id)
        {
            return true;
        }
    }
}