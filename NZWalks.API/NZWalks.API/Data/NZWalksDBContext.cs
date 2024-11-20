using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Data
{
    public class NZWalksDBContext : DbContext
    {
        public NZWalksDBContext(DbContextOptions<NZWalksDBContext> options) : base(options)
        {

        }

        public DbSet<Region> Regions { get; set; } //Create Regions Table if not exist in DB
        public DbSet<Walk> Walks { get; set; } //Create Walks Table if not exist in DB
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; } //Create WalkDifficulty Table if not exist in DB

        public DbSet<WalkDetailDTO> WalkDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); // Other configurations...
            modelBuilder.Entity<WalkDetailDTO>().HasNoKey().ToView(null); // Indicate that this entity has no key and is not mapped to a table
        }
    }
}
