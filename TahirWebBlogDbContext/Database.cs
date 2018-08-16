using Microsoft.EntityFrameworkCore;
using System;
using TahirWebBlogEntities;

namespace TahirWebBlogDbContext
{
    public class AppDatabase : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDatabase(DbContextOptions options) : base(options) { }
    }
}
