
using Api.Domain.Entity;
using Api.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Api.Infrastructure.Context
{
    public class GefContext(DbContextOptions<GefContext> options) : DbContext(options)
    {
        public DbSet<Bracelet> Bracelets { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<Shelter> Shelters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BraceletMapping());
            modelBuilder.ApplyConfiguration(new UserMapping());
            modelBuilder.ApplyConfiguration(new ShelterMapping());

        }

    }
}
