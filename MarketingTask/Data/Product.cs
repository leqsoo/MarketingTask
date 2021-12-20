using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketingTask.Data
{
    public class Product
    {
        /// <summary>
        /// იდენტიფიკატორი. ავტოინკრიმენტი.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        /// <summary>
        /// გასაყიდი პროდუქციის კოდი
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// გასაყიდი პროდუქციის დასახელება
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// გასაყიდი პროდუქციის ერთეულის ფასი
        /// </summary>
        public double PricePerProduct { get; set; }
    }
}
