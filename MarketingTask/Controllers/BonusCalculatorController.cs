using AutoMapper;
using MarketingTask.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MarketingTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BonusCalculatorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BonusCalculatorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CalculateBonus(DateTime startDate, DateTime endDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            decimal bonus = 0;
            var distributorSales = await _unitOfWork.DistributorSales.GetAll(d => startDate < d.SaleDate && d.SaleDate < endDate);

            if (distributorSales.Any())
            {
                foreach (var item in distributorSales)
                {
                    bonus += item.TotalSoldAmount;
                }
            }

            return Ok(bonus);
        }
    }
}