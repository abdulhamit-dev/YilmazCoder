using YilmazCoder.Core.Entities.Concrete;
using YilmazCoder.Entities;
using Microsoft.EntityFrameworkCore;

namespace YilmazCoder.DataAccess.Concrete.EntityFramework.Context
{
    public class YilmazCoderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=YilmazCoderDb;Trusted_Connection=true");
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
