using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTO;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultyController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper mapper;

        public WalkDifficultyController(IWalkDifficultyRepository walkDifficultyRepository,IMapper mapper) 
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllWalkDifficultyAsync()
        {
            var allWalkDifficulty = await walkDifficultyRepository.GetAllAsync();
            if(allWalkDifficulty == null) 
            {
                return NotFound();
            }
            var walkDiffDTO = mapper.Map<List<Models.DTO.WalkDifficultyDTO>>(allWalkDifficulty);
            return Ok(allWalkDifficulty);
        }

        [HttpGet("{id:guid}", Name = "GetWalkDifficultyByIdAsync")]
        [ActionName("GetWalkDifficultyByIdAsync")]
        public async Task<IActionResult> GetWalkDifficultyByIdAsync(Guid id)
        {
            var walkDifficulty = await walkDifficultyRepository.GetAsync(id);
            if(walkDifficulty == null)
            {
                return NotFound();
            }
            var walkDifficultyDTO = mapper.Map < Models.DTO.WalkDifficultyDTO>(walkDifficulty);
            return Ok(walkDifficultyDTO);
        }

        [HttpPost]
        [Route("AddWalkDifficulty")]
        public async Task<IActionResult> AddWalkDifficultyAsync(Models.DTO.addWalkDifficultyRequestDTO addWalkDifficultyRequestDTO)
        {
            //Convert DTO to Domain
            var walkDiffDomainData = mapper.Map<Models.Domain.WalkDifficulty>(addWalkDifficultyRequestDTO);
            // Pass Domain object to Repository
            walkDiffDomainData = await walkDifficultyRepository.AddAsync(walkDiffDomainData);
            //Convert Domain Object to DTO
            var newWalkDiffDTO = mapper.Map<Models.DTO.WalkDifficultyDTO>(walkDiffDomainData);
            // Return DTO
            return CreatedAtAction(nameof(GetWalkDifficultyByIdAsync), new { id = newWalkDiffDTO.Id }, newWalkDiffDTO);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateWalkDiffculty([FromRoute] Guid id, [FromBody] updateWalkDiffcultyRquestDTO updateWalkDiffcultyRquestDTO)
        {
            //Convert DTO to Domain
            var walkDiffDomain = mapper.Map<Models.Domain.WalkDifficulty>(updateWalkDiffcultyRquestDTO);

            //Fecth Data from Database - domian walk using repository
            walkDiffDomain = await walkDifficultyRepository.UpdateAsync(id, walkDiffDomain);
            if (walkDiffDomain == null)
            {
                return NotFound();
                ;
            }
            //Convert Domain to DTO
            var walkDiffDTOData = mapper.Map<Models.DTO.WalkDifficultyDTO>(walkDiffDomain);
            return Ok(walkDiffDTOData);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteWalkDifficultyByIdAsync(Guid id)
        {
            //Call repository to delete walk
            var walkDifficultyDomain = await walkDifficultyRepository.DeleteAsync(id);
            if (walkDifficultyDomain == null)
            {
                return NotFound();
            }
            var walkDifficultyDTO = mapper.Map<Models.DTO.WalkDifficultyDTO>(walkDifficultyDomain);
            return Ok(walkDifficultyDTO);
        }

    }
}
