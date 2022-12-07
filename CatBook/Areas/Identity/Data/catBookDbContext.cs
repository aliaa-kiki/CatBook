using catbook.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace CatBook.Areas.Identity.Data
{
    public class catBookDbContext : IdentityDbContext<CatBookUser>
    {
        public catBookDbContext(DbContextOptions<catBookDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<request>()
                .HasOne(e => e.requestedCat)
                .WithMany(z => z.receivedRequests)
                .OnDelete(DeleteBehavior.ClientSetNull);

            modelBuilder
                .Entity<cat>()
                .Property(p => p.status)
                .HasDefaultValue(statusStates.forAdoption);
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