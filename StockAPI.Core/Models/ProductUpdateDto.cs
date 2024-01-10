using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Core.Models
{
    public class ProductUpdateDto
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
