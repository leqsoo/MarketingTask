using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MarketingTask.Data
{
    public class Distributor
    {
        /// <summary>
        /// იდენტიფიკატორი. ავტოინკრიმენტი.
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long? ParentId { get; set; }

        /// <summary>
        /// სახელი - აუცილებელი, max 50 სიმბოლო.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// გვარი - აუცილებელი, max 50 სიმბოლო
        /// </summary>
        [Required]
        [StringLength(50)]
        public string SurName { get; set; }

        /// <summary>
        /// დაბადების თარიღი
        /// </summary>
        [Required]
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// სქესი
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// სურათი.
        /// </summary>
        //public byte[] Photo { get; set; }

        #region Personal Identification Information
        public string DocumentType { get; set; }

        /// <summary>
        /// საბუთის სერია - არააუცილებელი, max 10 სიმბოლო
        /// </summary>
        [StringLength(10)]
        public string DocumentSeria { get; set; }

        /// <summary>
        /// საბუთის ნომერი - არააუცილებელი, max 10 სიმბოლო.
        /// </summary>
        [StringLength(10)]
        public string DocumentNumber { get; set; }

        /// <summary>
        /// გაცემის თარიღი - აუცილებელი
        /// </summary>
        [Required]
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// საბუთის ვადა - აუცილებელი
        /// </summary>
        [Required]
        public DateTime ValidTroughDate { get; set; }

        /// <summary>
        /// პირადი ნომერი - აუცილებელი, max 50 სიმბოლო
        /// </summary>
        [Required]
        [StringLength(50)]
        public string PersonalNumber { get; set; }

        #endregion


        [Required]
        public string ContactType { get; set; }

        /// <summary>
        /// საკონტაქტო ინფორმაცია - აუცილებელი, max 100 სიმბოლო
        /// </summary>
        [Required]
        [StringLength(100)]
        public string ContactInformation { get; set; }

        public string AddressType { get; set; }

        /// <summary>
        /// მისამართი - აუცილებელი, max 100 სიმბოლო
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Address { get; set; }


        //public byte RecomendedCount { get; set; }

        //public byte HierarchyDepthCount { get; set; }
    }
}
