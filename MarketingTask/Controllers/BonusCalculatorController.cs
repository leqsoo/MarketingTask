using AutoMapper;
using MarketingTask.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MarketingTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusCalculatorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BonusCalculatorController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        //public async Task<IActionResult> CreateDistributor([FromBody] DateTime startDate, DateTime endDate)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }
        //    var bonus = _mapper.Map<Distributor>(createDistributorDto);
        //    await _unitOfWork.Distributors.Get(distributor);
        //    await _unitOfWork.Save();

        //    return CreatedAtRoute("GetDistributor", new { id = distributor.Id }, distributor);
        //}
    }
}
