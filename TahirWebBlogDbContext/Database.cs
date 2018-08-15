using Microsoft.EntityFrameworkCore;
using System;
using TahirWebBlogEntities;

namespace TahirWebBlogDbContext
{
    public class Database : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }

        public Database(DbContextOptions options) : base(options) { }
    }
}
