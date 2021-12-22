using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketingTask.Data
{
    public class DistributorSales
    {
        public long Id { get; set; }

        [ForeignKey(nameof(Distributor))]
        public long DistributorId { get; set; }
        public Distributor Distributor { get; set; }

        public DateTime SaleDate { get; set; }

        [ForeignKey(nameof(Product))]
        public long ProductId { get; set; }
        public Product Product { get; set; }

        public decimal TotalSoldProductPrice { get; set; }

        public decimal TotalSoldAmount { get; set; }
    }
}
