using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace TrialApplication.Entities
{
    public class TrialApplicationDbContext : IdentityDbContext<User>
    {

        public TrialApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
