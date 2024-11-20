using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Repositories
{
    public interface IWalkRepository
    {
        Task<IEnumerable<Walk>> GetAllAsync();
        Task<Walk> GetAsync(Guid id);
        Task<Walk> AddAsync(Walk walk);
        Task<Walk> DeleteAsync(Guid id);
        Task<Walk> UpdateAsync(Guid id, Walk region);
        Task<WalkDetailDTO> GetWalkDetailsAsync(Guid id);
    }
}
