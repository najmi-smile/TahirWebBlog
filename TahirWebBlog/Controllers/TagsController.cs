using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TahirWebBlogDbContext;
using TahirWebBlogEntities;
using TahirWebBlog.Models;
using System.Linq;
using System;

namespace TahirWebBlog.Controllers
{
    [Produces("application/json")]
    [Route("api/Tags")]
    public class TagsController : Controller
    {
        private AppDatabase Db { get; set; }
        public TagsController(AppDatabase db) { Db = db; }

        [HttpGet]
        [Route("")]
        public List<Tag> GetTags()
        {
            var tags = Db.Tags.ToList();
            return tags;
        }

        [HttpGet]
        [Route("{id}")]
        public Tag GetTag(int id)
        {
            var tag = Db.Tags.Where(t => t.TagId == id).SingleOrDefault();
            return new Tag()
            {
                TagId = tag.TagId,
                TagTitle = tag.TagTitle
            };
        }

        [HttpPost]
        [Route("new_tag")]
        public bool SaveTag(TagModel tag)
        {
            if (Db.Tags.Any(t => t.TagTitle == tag.TagTitle))
                ModelState.AddModelError("Tag", "Tag already exists");
            if (!ModelState.IsValid)
                return false;

            var newTag = new Tag()
            {
                TagTitle = tag.TagTitle
            };
            
            try
            {
                Db.Add<Tag>(newTag);
                Db.SaveChanges();
            }
            catch(Exception ex)
            {
                return false;
            }
            return true;
        }
        [HttpPut]
        [Route("update_tag")]
        public bool UpdateTag(TagModel tag)
        {
            return true;
        }
        [HttpDelete]
        [Route("{id}")]
        public bool DeleteTag(int id)
        {
            return true;
        }
    }
}