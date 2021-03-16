using CoderBlog.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoderBlog.DataAccess.Concrete
{
    public class CoderBlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CoderBlogDb;Trusted_Connection=true");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-8LA6RL0\SQLEXPRESS;Database=CoderBlogDb;Trusted_Connection=true");
        }

        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Yazi> Yazi { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
    }
}
