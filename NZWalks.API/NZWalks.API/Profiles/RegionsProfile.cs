using AutoMapper;
using NZWalks.API.Models.DTO;

namespace NZWalks.API.Profiles
{
    public class RegionsProfile : Profile
    {
        public RegionsProfile() 
        {
            // IF Domain Model and DIOs are different

            /*CreateMap<Models.Domain.Region, Models.DTO.RegionDTO>().
                ForMember(dest => dest.Id, options => options.MapFrom(src => src.Id));
            */
            CreateMap<Models.Domain.Region,Models.DTO.RegionDTO >().ReverseMap();
            CreateMap<Models.DTO.AddRegionRequestDTO, Models.Domain.Region>();
            CreateMap<Models.DTO.UpdateRegionRequestDTO, Models.Domain.Region>();

        }
    }
}
