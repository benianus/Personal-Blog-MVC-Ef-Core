using Microsoft.EntityFrameworkCore;
using PersonalBlog.Models;

namespace PersonalBlog.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<PersonModel> Persons { get; set; }
        public DbSet<AuthorModel> Authors { get; set; }
        public DbSet<ArticleModel> Articles { get; set; }
       
    }
}
