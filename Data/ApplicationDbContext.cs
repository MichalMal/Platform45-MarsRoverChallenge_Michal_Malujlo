using Microsoft.EntityFrameworkCore;
using Platform45_MarsRoverChallenge_Michal_Malujlo.Models;

namespace Platform45_MarsRoverChallenge_Michal_Malujlo.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<RoverModel> Rovers { get; set; }
    }
}
