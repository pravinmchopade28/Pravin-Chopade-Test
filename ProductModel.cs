using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PravinChopadeTest.Models
{
    public class ProductModel
    {
        [Required]
        public long ProductID { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]

        public decimal Price { get; set; }
        [Required]
        public bool IsGSTApplicable { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        [Required]
        public DateTime ExpireDate { get; set; }
        [Required]
        public string Color { get; set; }
    }
}
