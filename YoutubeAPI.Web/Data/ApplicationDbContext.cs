using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace YoutubeAPI.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Channel> Channels { get; set; }        
        public DbSet<Video> Videos { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
