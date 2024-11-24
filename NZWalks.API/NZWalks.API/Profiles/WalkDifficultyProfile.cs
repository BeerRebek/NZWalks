using AutoMapper;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Profiles
{
    public class WalkDifficultyProfile : Profile
    {
        public WalkDifficultyProfile()
        {
            CreateMap<Models.Domain.WalkDifficulty, Models.DTO.WalkDifficultyDTO>().ReverseMap();
            CreateMap<Models.DTO.addWalkDifficultyRequestDTO, Models.Domain.WalkDifficulty>();
            CreateMap<Models.DTO.updateWalkDiffcultyRquestDTO, Models.Domain.WalkDifficulty>();
        }
            
    }
}
