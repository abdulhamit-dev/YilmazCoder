using CoderBlog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoderBlog.DataAccess.Concrete
{
    public class CoderBlogContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=CoderBlogDb;Trusted_Connection=true");
        }

        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Yazi> Yazi { get; set; }
    }
}
