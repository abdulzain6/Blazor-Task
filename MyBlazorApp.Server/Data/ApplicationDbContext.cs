using Microsoft.EntityFrameworkCore;
using MyBlazorApp.Server.Models;


namespace MyBlazorApp.Server.Data{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }
}
