
namespace TahirWebBlogEntities
{
    public class CommentTag
    {
        public int Id { get; set; }
        public int FK_CommentId { get; set; }
        public int FK_TagId { get; set; }
    }
}
