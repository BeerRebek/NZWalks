using AutoMapper;

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
            CreateMap<Models.Domain.Region, Models.DTO.RegionDTO>().ReverseMap();

        }
    }
}
