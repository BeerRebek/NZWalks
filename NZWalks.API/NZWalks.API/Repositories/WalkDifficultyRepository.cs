using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NZWalksDBContext nZWalksDBContext;

        public WalkDifficultyRepository(NZWalksDBContext nZWalksDBContext) 
        {
            this.nZWalksDBContext = nZWalksDBContext;
        }
        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await nZWalksDBContext.WalkDifficulty.ToListAsync();
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDiff)
        {
            walkDiff.Id = Guid.NewGuid();
            await nZWalksDBContext.AddAsync(walkDiff);
            await nZWalksDBContext.SaveChangesAsync();
            return walkDiff;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var walkDiff = await nZWalksDBContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
            if (walkDiff == null)
            {
                return null;
            }

            // Delete the region
            nZWalksDBContext.WalkDifficulty.Remove(walkDiff);
            await nZWalksDBContext.SaveChangesAsync();
            return walkDiff;
        }

        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            var walkDiff = await nZWalksDBContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
            if(walkDiff == null)
            {
                return null;
            }
            return walkDiff;
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDiff)
        {
            var exisitngWalkDiff = await nZWalksDBContext.WalkDifficulty.FirstOrDefaultAsync(x => x.Id == id);
            if (exisitngWalkDiff == null)
            {
                return null;
            }
            exisitngWalkDiff.Code = walkDiff.Code;

            await nZWalksDBContext.SaveChangesAsync();
            return exisitngWalkDiff;
        }
    }
}
