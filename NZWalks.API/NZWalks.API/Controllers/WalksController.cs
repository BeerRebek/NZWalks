using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.Domain;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalksController : Controller
    {
        private readonly IWalkRepository walkRepository;
        private readonly IMapper mapper;

        public WalksController(IWalkRepository walkRepository,IMapper mapper) {
            this.walkRepository = walkRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async  Task<IActionResult>  GetAllWalksAsync() 
        {
            //Fetch data from database - domain walks
            var walksDomainData = await walkRepository.GetAllAsync();

            //Convert domain walks to DTO walks
            var walksDTO = mapper.Map<List<Models.DTO.WalkDTO>>(walksDomainData);
            //Return reponse
            return Ok(walksDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetWalkByID(Guid id)
        {
            //Fetch Data from Data - domain walks
            var walkDomainData = await walkRepository.GetAsync(id);
            if(walkDomainData == null)
            {
                return NotFound();
            }
            //Convvert domain walk to DTO walk
            var walkDTO = mapper.Map<Models.DTO.WalkDTO>(walkDomainData);  
            //Return response
            return Ok(walkDTO);
        }


        [HttpPost]
        public async Task<IActionResult> AddWalkAsync([FromBody] AddWalkRequestDTO addWalkRequestDTO)
        {
            //Conventional Convertion of  DTO to Domain
            /*
            var walkDomain = new Models.Domain.Walk
            {
                Length = addWalkRequestDTO.Length,
                Name = addWalkRequestDTO.Name,
                RegionId = addWalkRequestDTO.RegionId,
                WalkDifficultyId = addWalkRequestDTO.WalkDifficultyId
            };
            */
            var walkDomainData = mapper.Map<Models.Domain.Walk>(addWalkRequestDTO);
            
            // Pass Domain object to Repository
            walkDomainData = await walkRepository.AddAsync(walkDomainData);

            //Convert Domain Object to DTO
            /*
            var newWalkDTO = new Models.DTO.WalkDTO
            {
                Id = walkDomain.Id,
                Name = walkDomain.Name,
                Length = walkDomain.Length,
                RegionId = walkDomain.RegionId,
                WalkDifficultyId = walkDomain.WalkDifficultyId
            };
            */
            var newWalkDTO = mapper.Map<Models.DTO.WalkDTO>(walkDomainData);
            // Return DTO
            return CreatedAtAction(nameof(GetWalkByID),new {id =  newWalkDTO.Id},newWalkDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateWalkById([FromRoute]Guid id, [FromBody]  UpdateWalkRequestDTO updateWalkRequestDTO)
        {
            //Convert DTO to Domain
            var walkDomain = mapper.Map<Models.Domain.Walk>(updateWalkRequestDTO);

            //Fecth Data from Database - domian walk using repository
            walkDomain = await walkRepository.UpdateAsync(id, walkDomain);
            if(walkDomain == null)
            {
                return NotFound();
;           }
            //Convert Domain to DTO
            var walkDTOData = mapper.Map<Models.DTO.WalkDTO>(walkDomain);
            return Ok(walkDTOData);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkByIdAsync(Guid id)
        {
            //Call repository to delete walk
            var walkDomain = await walkRepository.DeleteAsync(id);
            if(walkDomain == null)
            {
                return NotFound();
            }
            var walkDTO = mapper.Map<Models.DTO.WalkDTO>(walkDomain);
            return Ok(walkDTO);
        }

        [HttpGet("{id}/walkdetails")]
        public async Task<IActionResult> GetWalkDeatilsByIdAsync(Guid id)
        {
            try
            {
                var walkDetails = await walkRepository.GetWalkDetailsAsync(id);
                if (walkDetails == null)
                {
                    return NotFound();
                }
                return Ok(walkDetails);
            }
            catch(Exception ex)
            {
                return StatusCode(500, "An internal server error occurred.");
            }
        }
    }
}
