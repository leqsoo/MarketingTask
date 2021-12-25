using AutoMapper;
using MarketingTask.Data;
using MarketingTask.IRepository;
using MarketingTask.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDistributorSales(long distributorId, DateTime? saleDate, long productId)
        {
            IList<DistributorSales> distributorSales = new List<DistributorSales>();
            if (distributorId > 0)
            {
                distributorSales = await _unitOfWork.DistributorSales.GetAll(d => d.DistributorId == distributorId,
                    includes: new List<string> { "Distributor" });
            }
            if (productId > 0)
            {
                distributorSales = await _unitOfWork.DistributorSales.GetAll(d => d.ProductId == productId,
                    includes: new List<string> { "Product" });
            }
            if (saleDate != null)
            {
                distributorSales = await _unitOfWork.DistributorSales.GetAll(d => d.SaleDate == saleDate,
                    includes: new List<string> { "Product", "Distributor" });
            }
            var results = _mapper.Map<List<DistributorSalesDto>>(distributorSales);
            return Ok(results);
        }

        [HttpGet("{id:int}", Name = "GetDistributorSale")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetDistributorSale(long id)
        {
            var distributorSales = await _unitOfWork.DistributorSales.GetAll(d => d.Id == id);
            var result = _mapper.Map<List<DistributorSalesDto>>(distributorSales);
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

            return CreatedAtRoute("GetDistributorSale", new { id = distributorSales.Id }, distributorSales);
        }
    }
}
