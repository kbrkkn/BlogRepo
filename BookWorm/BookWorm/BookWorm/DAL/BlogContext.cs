using BookWorm.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace BookWorm.DAL
{
    public class BlogContext : DbContext
    {
        public BlogContext(): base("BlogContext")
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}