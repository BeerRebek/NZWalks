using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
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

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionAsync")]    
        public async Task<IActionResult> GetRegionAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);
            if(region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<Models.DTO.RegionDTO>(region);
            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<ActionResult> AddRegionAsync(AddRegionRequestDTO addRegionRequestDTO)
        {
            //Conventional conversion of Request(DTO) to DOMAIN model
            var region = new Models.Domain.Region()
            {
                Code = addRegionRequestDTO.Code,
                Area = addRegionRequestDTO.Area,
                Lat = addRegionRequestDTO.Lat,
                Long = addRegionRequestDTO.Long,
                Name = addRegionRequestDTO.Name,
                Population = addRegionRequestDTO.Population
            };


            //Pass details to Repository
            region = await regionRepository.AddAsync(region);

            //Conventional conversion back to DTO
            var regionDTO = new Models.DTO.RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };

            return CreatedAtAction(nameof(GetRegionAsync),new { id = regionDTO.Id }, regionDTO); 
            // Status 201 : New Resource has been created
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionAsyncById(Guid id)
        {
            // Get region from database
            var region = await regionRepository.DeleteAsync(id);

            // If null NotFound
            if(region == null )
            {
                return NotFound();
            }
            // Convert response back to DTO
            var regionDTO = new Models.DTO.RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };

            // return ok
            return Ok(regionDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateResultAsync([FromRoute]Guid id,[FromBody] Models.DTO.UpdateRegionRequestDTO updateRegionRequestDTO)
        {
            // Convert DTO to DOMAIN model
            var region = new Models.Domain.Region()
            {
                Area = updateRegionRequestDTO.Area,
                Lat = updateRegionRequestDTO.Lat,
                Long = updateRegionRequestDTO.Long,
                Name = updateRegionRequestDTO.Name,
                Population = updateRegionRequestDTO.Population
            };

            //Udpate Region using repository
           region =await regionRepository.UpdateAsync(id, region);

            // If null NotFound
            if(region == null)
            {
                return NotFound();
            }
            //Convert Domain to DTO
            var regionDTO = new Models.DTO.RegionDTO
            {
                Id = region.Id,
                Code = region.Code,
                Area = region.Area,
                Lat = region.Lat,
                Long = region.Long,
                Name = region.Name,
                Population = region.Population
            };
            //Return OK response
            return Ok(regionDTO);
        }
    }
}
