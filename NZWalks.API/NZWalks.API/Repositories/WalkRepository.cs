using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NZWalks.API.Data;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using System.Data;

namespace NZWalks.API.Repositories
{
    public class WalkRepository : IWalkRepository
    {
        private readonly NZWalksDBContext nZWalksDBContext;

        public WalkRepository(NZWalksDBContext nZWalksDBContext)
        {
            this.nZWalksDBContext = nZWalksDBContext;
        }
        public async Task<Walk> AddAsync(Walk walk)
        {
            //Assign New ID
            walk.Id = Guid.NewGuid();
            await nZWalksDBContext.AddAsync(walk);
            await nZWalksDBContext.SaveChangesAsync();
            return walk;
        }

        public async Task<Walk> DeleteAsync(Guid id)
        {
            var existingWalk = await nZWalksDBContext.Walks.FindAsync(id);
            if (existingWalk == null)
            {
                return null;
            }
            // Delete the region
            nZWalksDBContext.Walks.Remove(existingWalk);
            await nZWalksDBContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<IEnumerable<Walk>> GetAllAsync()
        {
            return await 
                nZWalksDBContext.Walks
                .Include(x=>x.Region)
                .Include(x=>x.WalkDifficulty)
                .ToListAsync();
        }

        public async Task<Walk> GetAsync(Guid id)
        {
            var walk = await nZWalksDBContext.Walks
                .Include(x => x.Region)
                .Include(x => x.WalkDifficulty)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (walk == null)
            {
                return null;
            }
            return walk;
        }

        public async Task<Walk> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await nZWalksDBContext.Walks.FindAsync(id);
            if (existingWalk == null)
            {
                return null;
            }
            existingWalk.Name = walk.Name;
            existingWalk.Length = walk.Length;
            existingWalk.WalkDifficultyId = walk.WalkDifficultyId;
            existingWalk.RegionId = walk.RegionId;
            await nZWalksDBContext.SaveChangesAsync();
            return existingWalk;
        }

        public async Task<WalkDetailDTO> GetWalkDetailsAsync(Guid Walkdid)
        {
            try
            {
                var parameter = new SqlParameter("@WalkId", SqlDbType.UniqueIdentifier)
                {
                    Value = Walkdid
                };

                var walkDetails = await nZWalksDBContext.WalkDetails.FromSqlRaw("EXEC GetWalkDetails @WalkId", parameter).ToListAsync();
                if (walkDetails == null)
                {
                    return null;
                }
                return walkDetails.FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while retrieving walk details.", ex);
            }
        }
    }
}
