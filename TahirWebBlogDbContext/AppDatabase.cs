using Microsoft.EntityFrameworkCore;
using System;
using TahirWebBlogEntities;

namespace TahirWebBlogDbContext
{
    public class AppDatabase : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }

        public AppDatabase(DbContextOptions options) : base(options) { }
    }
}
