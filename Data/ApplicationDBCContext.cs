using Microsoft.EntityFrameworkCore;
using API2.Models;
namespace API2.Data
{
    public class ApplicationDBCContext:DbContext 
    {
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public ApplicationDBCContext(DbContextOptions options) : base(options)
        {

        }
    }
}
