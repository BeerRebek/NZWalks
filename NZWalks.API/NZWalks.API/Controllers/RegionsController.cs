using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using NZWalks.API.Models.Domain;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository,IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GellAllRegions()
        {
            /*Static List of Region
            var regions = new List<Region>() 
            { 
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name="Wellinton",
                    Code = "WLG",
                    Area = 227755,
                    Lat = -1.88834,
                    Long = 2299.88,
                    Population = 50000
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name="Auckland",
                    Code = "AUCK",
                    Area = 227735,
                    Lat = -1.883434,
                    Long = 22329.83,
                    Population = 60000
                },
            };
            */

            var regions = await regionRepository.GetAllAsync();

            // Return DTO regions - Without Using AutoMapper
            /*var regionsDTO = new List<Models.DTO.RegionDTO>();
            regions.ToList().ForEach(DomainRegion =>
            {
                var regionDTO = new Models.DTO.RegionDTO()
                {
                    Id = DomainRegion.Id,
                    Name = DomainRegion.Name,
                    Area = DomainRegion.Area,
                    Code = DomainRegion.Code,
                    Lat = DomainRegion.Lat,
                    Long = DomainRegion.Long,
                    Population = DomainRegion.Population 
                };
                regionsDTO.Add(regionDTO);
            });
            */

            //Return DTO Regions -Using AutoMapper to MAP DTO to Domain model
            var regionsDTO =mapper.Map<List<Models.DTO.RegionDTO>>(regions);
            return Ok(regionsDTO);
        }
    }
}
