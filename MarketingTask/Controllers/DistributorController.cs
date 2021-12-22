using AutoMapper;
using MarketingTask.Data;
using MarketingTask.IRepository;
using MarketingTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DistributorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDistributors()
        {
            var distributors = await _unitOfWork.Distributors.GetAll();
            var results = _mapper.Map<List<DistributorDto>>(distributors);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetDistributor")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDistributor(long id)
        {
            var distributor = await _unitOfWork.Distributors.Get(c => c.Id == id);
            var result = _mapper.Map<DistributorDto>(distributor);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateDistributor([FromBody] CreateDistributorDto createDistributorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var distributors = (await _unitOfWork.Distributors.GetAll());   
            if (distributors.Any())
            {
                if (distributors.Where(d => d.ParentId == createDistributorDto.ParentId).Count() >= 3)
                {
                    return BadRequest("This distributor Can't have, More recomended Coworkers");
                }
            }
            var distributor = _mapper.Map<Distributor>(createDistributorDto);
            await _unitOfWork.Distributors.Insert(distributor);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetDistributor", new { id = distributor.Id }, distributor);
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateDistributor(long id, [FromBody] UpdateDistributorDto DistributorDto)
        {
            if (!ModelState.IsValid || id < 1)
            {
                return BadRequest(ModelState);
            }
            var distributor = await _unitOfWork.Distributors.Get(c => c.Id == id);
            if (distributor == null)
            {
                return BadRequest("Submited Date is invalid");
            }
            _mapper.Map(DistributorDto, distributor);
            _unitOfWork.Distributors.Update(distributor);
            await _unitOfWork.Save();

            return NoContent();
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteDistributor(long id)
        {
            if (!ModelState.IsValid || id < 1)
            {
                return BadRequest(ModelState);
            }
            var Distributor = await _unitOfWork.Distributors.Get(c => c.Id == id);
            if (Distributor == null)
            {
                return BadRequest("Submited Data is invalid");
            }
            await _unitOfWork.Distributors.Delete(id);
            await _unitOfWork.Save();

            return NoContent();
        }
    }
}
