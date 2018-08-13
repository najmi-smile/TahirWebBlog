using System;

namespace TahirWebBlogEntities
{
    public class Article
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ArticleId { get; set; }
        public string ArticleTitle { get; set; }
        //public string ArticleBody { get; set; }
        //public string BelongsTo { get; set; }
        //public int Votes { get; set; }
        //public DateTime CreatedBy { get; set; }
        //public DateTime CreatedAt { get; set; }
        //public string ImageUrl { get; set; } 
    }
}
