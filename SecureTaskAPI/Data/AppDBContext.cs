using Microsoft.EntityFrameworkCore;
using SecureTaskAPI.Models;

namespace SecureTaskAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<ApiModel> ApiModel { get; set; }
    }
}
