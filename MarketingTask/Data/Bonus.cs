using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketingTask.Data
{
    public class Bonus
    {
        /// <summary>
        /// იდენტიფიკატორი. ავტოინკრიმენტი.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey(nameof(Distributor))]
        public long DistributorId { get; set; }
        public Distributor Distributor { get; set; }

        public decimal BonusAmount { get; set; }
    }
}
