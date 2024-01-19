using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StockAPI.Core.Models
{
    public class StockItemModel
    {
        [Key]
        public int StockItemId { get; set; }

        public int ProductId { get; set; }
        public ProductModel Product { get; set; }
        public int StoreId { get; set; }
        public StoreModel Store { get; set; }
        public int Quantity { get; set; }
    }
}
