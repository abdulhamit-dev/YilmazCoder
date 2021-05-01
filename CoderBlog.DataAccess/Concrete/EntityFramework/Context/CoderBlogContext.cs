using CoderBlog.Core.Entities.Concrete;
using CoderBlog.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoderBlog.DataAccess.Concrete.EntityFramework.Context
{
    public class CoderBlogContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CoderBlogDb;Trusted_Connection=true");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-8LA6RL0\SQLEXPRESS;Database=CoderBlogDb;Trusted_Connection=true");
            optionsBuilder.UseSqlServer(@"Server=89.252.180.91\MSSQLSERVER2016;Database=yilmazcode_blog;User ID=yilmazcode_user;Password=5^K03imt");
        }

        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Yetki> Yetki { get; set; }
        public DbSet<KullaniciYetki> KullaniciYetki { get; set; }
        public DbSet<Yazi> Yazi { get; set; }
        public DbSet<Kategori> Kategori { get; set; }
        public DbSet<Yorum> Yorum { get; set; }
        public DbSet<Begeni> Begeni { get; set; }
    }
}
