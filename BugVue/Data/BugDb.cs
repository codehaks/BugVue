using BugVue.Models;
using Microsoft.EntityFrameworkCore;

namespace BugVue.Data
{
    public class BugDbContext:DbContext
    {
        public BugDbContext(DbContextOptions<BugDbContext> options)
                : base(options)
            {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Bug> Bugs { get; set; }
        
    }
}