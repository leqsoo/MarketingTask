using System.ComponentModel.DataAnnotations;

namespace MarketingTask.Models
{
    public class ProductDto : CreateProductDto
    {
    }
    public class CreateProductDto
    {
        /// <summary>
        /// გასაყიდი პროდუქციის კოდი
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// გასაყიდი პროდუქციის დასახელება
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// გასაყიდი პროდუქციის ერთეულის ფასი
        /// </summary>
        [Required]
        public double PricePerProduct { get; set; }
    }
}
