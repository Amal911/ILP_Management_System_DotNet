using ILPManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace ILPManagementSystem.Data
{
    public class ApiContext:DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> dbContextOptions): base (dbContextOptions)
        {
            
        }
        public DbSet<User>  Users { get; set; }
        public DbSet<Scorecard> Scorecards { get; set; }
    }
}
