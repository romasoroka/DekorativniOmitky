using Microsoft.EntityFrameworkCore;
using WebSiteRazorPages.Models;

namespace WebSiteRazorPages.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {
            
        }
        public DbSet<Category> Categories {  get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { DisplayOrder = 1, Id = 1, Name = "Action" },
                new Category { DisplayOrder = 2, Id = 2, Name = "Void" },
                new Category { DisplayOrder = 3, Id = 3, Name = "Republic" }
                );
        }
    }
}
