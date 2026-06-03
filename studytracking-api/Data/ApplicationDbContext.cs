using Microsoft.EntityFrameworkCore;
using studytracking_api.Models.Entities;

namespace studytracking_api.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        public DbSet<User> User { get; set; }
    }
}
