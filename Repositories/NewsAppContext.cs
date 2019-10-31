using Microsoft.EntityFrameworkCore;
using Entities;

namespace Repositories
{
    public class NewsAppContext : DbContext
    {
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<City> Cities { get; set; }

        public NewsAppContext() : base()
        { }

        public NewsAppContext(DbContextOptions options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Subscription>(entity =>
            {
                entity.Property(p => p.Id)
                      .ValueGeneratedNever();
            });

            builder.Entity<City>(entity =>
            {
                entity.Property(p => p.Id)
                    .ValueGeneratedOnAdd();
            });
        }
    }
}
