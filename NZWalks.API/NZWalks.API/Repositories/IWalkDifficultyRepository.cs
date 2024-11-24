using NZWalks.API.Models.Domain;

namespace NZWalks.API.Repositories
{
    public interface IWalkDifficultyRepository
    {
        Task<IEnumerable<WalkDifficulty>>GetAllAsync();
        Task<WalkDifficulty> AddAsync(WalkDifficulty walkDiff);
        Task<WalkDifficulty> GetAsync(Guid id);
        Task<WalkDifficulty> DeleteAsync(Guid id);
        Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDiff);
    }
}
