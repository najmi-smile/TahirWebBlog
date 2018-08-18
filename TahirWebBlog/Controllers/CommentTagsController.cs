using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TahirWebBlogDbContext;
using TahirWebBlog.Models;
using System.Linq;
using System;
using TahirWebBlogEntities;

namespace TahirWebBlog.Controllers
{
    [Produces("application/json")]
    [Route("api/CommentTags")]
    public class CommentTagsController : Controller
    {
        private AppDatabase Db { get; set; }
        public CommentTagsController(AppDatabase db) { Db = db; }

        [HttpGet]
        [Route("")]
        public List<CommentTag> GetCommentTags()
        {
            var commentTags = Db.CommentTags.ToList();
            return commentTags;
        }
        [HttpGet]
        [Route("{id}")]
        public CommentTag GetCommentTag(int id)
        {
            try
            {
                var comment = Db.CommentTags.Where(ct => ct.Id == id).SingleOrDefault();
                return new CommentTag()
                {
                    Id = comment.Id,
                    FK_CommentId = comment.FK_CommentId,
                    FK_TagId = comment.FK_TagId
                };
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        [HttpPost]
        [Route("")]
        public bool SaveComment(CommentTagModel commentTag)
        {
            // TODO! Need to bring the user and article/post id to presist comment
            if (!ModelState.IsValid)
                return false;      
            try
            {
                CommentTag newCommentTag = new CommentTag()
                {
                    FK_CommentId = commentTag.FK_CommentId,
                    FK_TagId = commentTag.FK_TagId
                };
                Db.Add<CommentTag>(newCommentTag);
                Db.SaveChanges();
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        [HttpPut]
        [Route("{id}")]
        public bool UpdateComment(int id, CommentTagModel commentTag)
        {
            if (!ModelState.IsValid)
                return false;

            if (Db.CommentTags.Any(ct => ct.Id == id))
            {
                try
                {
                    var updatedCommentTag = new CommentTag()
                    {
                        Id = id,
                        FK_TagId = commentTag.FK_TagId,
                        FK_CommentId = commentTag.FK_CommentId
                    };
                    Db.CommentTags.Update(updatedCommentTag);
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
        public bool DeleteComment(int id)
        {
            try
            {
                Db.CommentTags.Remove(Db.CommentTags.Where(ct => ct.Id == id).SingleOrDefault());
                Db.SaveChanges();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return true;
        }
    }
}