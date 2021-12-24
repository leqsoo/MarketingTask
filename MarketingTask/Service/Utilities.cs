using MarketingTask.Data;
using System.Collections.Generic;
using System.Linq;

namespace MarketingTask.Service
{
    public class Utilities
    {
        public static long GetLevel(IList<Distributor> distributors, long? parentId)
        {
            var parent = distributors.FirstOrDefault(d => d.Id == parentId);

            if (parent == null)
            {
                return 1;
            }

            return 1 + GetLevel(distributors, (long)parent.ParentId);
        }

        public static decimal GetChildrenBonus(IList<DistributorSales> distributorSales, long distributorId)
        {
            var sales = distributorSales.Where(d => d.Distributor.ParentId == distributorId);
            decimal Bonus = 0;
            if (sales.Any())
            {
                foreach (var sale in sales)
                {
                    Bonus += (sale.TotalSoldAmount / 20);
                    foreach (var level3sale in distributorSales.Where(d => d.Distributor.ParentId == sale.DistributorId))
                    {
                        if (level3sale != null)
                        {
                            Bonus += (level3sale.TotalSoldAmount / 100);
                        }
                    }
                }
            }
            return Bonus;
        }
    }
}