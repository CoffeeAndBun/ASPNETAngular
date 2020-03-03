using Microsoft.AspNet.Identity.EntityFramework;
using System.Configuration;
using System.Data.Entity;
using WebApi.Models.Entities;

namespace WebApi.Models
{
    public class CnBContext : IdentityDbContext
    {
        public CnBContext() : base(ConfigurationManager.ConnectionStrings["CnBContext"].ConnectionString)
        {

        }

        public DbSet<Book> books { get; set; }
        public DbSet<Review> reviews { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasMany(x => x.Reviews).WithRequired().HasForeignKey(x => x.BookId);
        }
    }
}