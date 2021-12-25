using MarketingTask.Data;
using MarketingTask.IRepository;
using MarketingTask.Service;
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
    public class BonusCalculatorController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public BonusCalculatorController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetBonuses(string name, string surname, decimal? minbonus, decimal? maxbonus)
        {
            IList<Bonus> distributorBonuses = new List<Bonus>();
            if (!string.IsNullOrEmpty(name))
            {
                distributorBonuses = await _unitOfWork.Bonuses.GetAll(d => d.Distributor.Name == name, 
                    includes: new List<string> { "Distributor" });
            }
            if (!string.IsNullOrEmpty(surname))
            {
                distributorBonuses = await _unitOfWork.Bonuses.GetAll(d => d.Distributor.SurName == surname,
                    includes: new List<string> { "Distributor" });
            }
            if (minbonus != null)
            {
                distributorBonuses = await _unitOfWork.Bonuses.GetAll(d => minbonus > d.BonusAmount,
                includes: new List<string> { "Distributor" });
            }
            if (maxbonus != null)
            {
                distributorBonuses = await _unitOfWork.Bonuses.GetAll(d => maxbonus < d.BonusAmount,
                    includes: new List<string> { "Distributor" });
            }
            return Ok(distributorBonuses);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CalculateBonus(DateTime startDate, DateTime endDate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            decimal bonus = 0;
            var distributorSales = await _unitOfWork.DistributorSales.GetAll(d => startDate <= d.SaleDate
            && d.SaleDate <= endDate && d.IsUsedForBonusCalculation == false, null, new List<string> { "Distributor" });

            if (distributorSales.Any())
            {
                foreach (var distributor in distributorSales)
                {
                    bonus = 0;
                    //საკუთარი გაყიდვები
                    foreach (var sale in distributorSales.Where(t => t.DistributorId == distributor.DistributorId))
                    {
                        bonus += (sale.TotalSoldAmount / 10);
                    }
                    bonus += Utilities.GetChildrenBonus(distributorSales, distributor.DistributorId);
                    await _unitOfWork.Bonuses.Insert(new Bonus { DistributorId = distributor.DistributorId, BonusAmount = bonus });
                }
            }
            if (!distributorSales.Any() || bonus == 0)
            {
                return BadRequest("Nothing to calculate at given date range");
            }
            foreach (var sale in distributorSales)
            {
                sale.IsUsedForBonusCalculation = true;
            }
            _unitOfWork.DistributorSales.UpdateRange(distributorSales);
            await _unitOfWork.Save();
            return Ok("Bonus has been Calculated");
        }
    }
}