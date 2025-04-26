using Microsoft.EntityFrameworkCore;
using API2.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
namespace API2.Data
{
    public class ApplicationDBCContext: IdentityDbContext<AppUser>
    {
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<AppUser> AppUser { get; set; }
        public ApplicationDBCContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            List<IdentityRole> roles = new List<IdentityRole>() {
                new IdentityRole {
                     Id = "1", // Valeur fixe
                    Name = "Admin",
                    NormalizedName = "ADMIN" 
                },
                new IdentityRole {
                     Id = "2", // Valeur fixe
                    Name = "User"
                , NormalizedName = "USER" 
                }
            };
            modelBuilder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
