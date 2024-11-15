using Microsoft.EntityFrameworkCore;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Data
{
    public class NZWalksDBContext : DbContext
    {
        public NZWalksDBContext(DbContextOptions<NZWalksDBContext> options): base(options)
        {
            
        }

        public DbSet<Region> Regions { get; set; } //Create Regions Table if not exist in DB
        public DbSet<Walk> Walks { get; set; } //Create Walks Table if not exist in DB
        public DbSet<WalkDifficulty> WalkDifficulty { get; set; } //Create WalkDifficulty Table if not exist in DB
    }
}
