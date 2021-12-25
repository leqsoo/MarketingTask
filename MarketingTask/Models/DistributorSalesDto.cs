using MarketingTask.Data;
using System;

namespace MarketingTask.Models
{
    public class DistributorSalesDto : CreateDistributorSalesDto
    {

    }
    public class CreateDistributorSalesDto
    {
        public long Id { get; set; }

        public long DistributorId { get; set; }
        public Distributor Distributor { get; set; }

        public DateTime SaleDate { get; set; }

        public long ProductId { get; set; }
        public Product Product { get; set; }

        public decimal TotalSoldProductPrice { get; set; }

        public decimal TotalSoldAmount { get; set; }
    }
}
