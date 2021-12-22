using AutoMapper;
using MarketingTask.Data;
using MarketingTask.IRepository;
using MarketingTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistributorSalesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public DistributorSalesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("{id:int}", Name = "GetDistributorSales")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDistributorSales(long id)
        {
            var distributorSales = await _unitOfWork.DistributorSales.Get(c => c.Id == id);
            var result = _mapper.Map<DistributorSalesDto>(distributorSales);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateDistributorSales([FromBody] CreateDistributorSalesDto createDistributorDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var distributorSales = _mapper.Map<DistributorSales>(createDistributorDto);
            await _unitOfWork.DistributorSales.Insert(distributorSales);
            await _unitOfWork.Save();

            return CreatedAtRoute("GetDistributorSales", new { id = distributorSales.Id }, distributorSales);
        }
    }
}
