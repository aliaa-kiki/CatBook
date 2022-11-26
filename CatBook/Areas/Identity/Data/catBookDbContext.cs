using catbook.Models;
using Microsoft.EntityFrameworkCore;

namespace CatBook.Areas.Identity.Data
{
    public class catBookDbContext : DbContext
    {
        public catBookDbContext(DbContextOptions<catBookDbContext> options) : base(options)
        {
        }

        public DbSet<cat> cats { get; set; }
        public DbSet<catTrait> catTraits { get; set; }
        public DbSet<trait> traits { get; set; }
        public DbSet<request> requests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = CatBook; Trusted_Connection = True; MultipleActiveResultSets = true");
            base.OnConfiguring(optionsBuilder);
        }
    }
}