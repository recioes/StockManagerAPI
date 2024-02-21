
using System.ComponentModel.DataAnnotations;

namespace StockAPI.Core.DTOs
{
    public class ProductDto
    {
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Range(0.01, 10000.00)]
        public float Price { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

    }
}
