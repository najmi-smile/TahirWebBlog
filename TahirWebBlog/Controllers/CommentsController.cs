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
    [Route("api/Comments")]
    public class CommentsController : Controller
    {
        private AppDatabase Db { get; set; }
        public CommentsController(AppDatabase db) { Db = db; }

        [HttpGet]
        [Route("")]
        public List<Comment> GetComments()
        {
            var comments = Db.Comments.ToList();
            return comments;
        }
        [HttpGet]
        [Route("{id}")]
        public Comment GetComment(int id)
        {
            try
            {
                var comment = Db.Comments.Where(c => c.CommentId == id).SingleOrDefault();
                return new Comment()
                {
                    CommentId = comment.CommentId,
                    CommentBody = comment.CommentBody
                };
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
        }
        [HttpPost]
        [Route("")]
        public bool SaveComment(CommentModel comment)
        {
            // TODO! Need to bring the user and article/post id to presist comment
            if (!ModelState.IsValid)
                return false;

            var newComment = new Comment()
            {
                CommentBody = comment.CommentBody
            };

            try
            {
                Db.Add<Comment>(newComment);
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
        public bool UpdateComment(int id, CommentModel comment)
        {
            if (!ModelState.IsValid)
                return false;

            if (Db.Comments.Any(c => c.CommentId == id))
            {
                try
                {
                    var updatedComment = new Comment()
                    {
                        CommentId = id,
                        CommentBody = comment.CommentBody
                    };
                    Db.Comments.Update(updatedComment);
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
                Db.Comments.Remove(Db.Comments.Where(c => c.CommentId == id).SingleOrDefault());
                Db.SaveChanges();
            }
            catch (Exception ex) { throw new Exception(ex.Message); }
            return true;
        }
    }
}