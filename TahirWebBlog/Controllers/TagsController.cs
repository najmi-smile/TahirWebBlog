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
        // TODO! Manage exceptions, AppDatabase, query to find single tag

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
            try
            {
                var tag = Db.Tags.Where(t => t.TagId == id).SingleOrDefault();
                return new Tag()
                {
                    TagId = tag.TagId,
                    TagTitle = tag.TagTitle
                };
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
        }
        [HttpPost]
        [Route("")]
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
        [Route("{id}")]
        public bool UpdateTag(int id, TagModel tag)
        {
            if (!ModelState.IsValid)
                return false;

            if (Db.Tags.Any(t => t.TagId == id && t.TagTitle != tag.TagTitle))
            {
                try
                {
                    var newTag = new Tag()
                    {       
                        TagId = id,
                        TagTitle = tag.TagTitle
                    };
                    Db.Tags.Update(newTag);
                    Db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return false;
                }
            }   
            return true;
        }
        [HttpDelete]
        [Route("{id}")]
        public bool DeleteTag(int id)
        {
            try
            {
                Db.Tags.Remove(Db.Tags.Where(t => t.TagId == id).SingleOrDefault());
                Db.SaveChanges();
            }
            catch(Exception ex) { throw new Exception(ex.Message); }
            return true;
        }
    }
}