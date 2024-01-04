using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StockAPI.Core.Models
{
    public class StockItemModel
    {
        public int StoreItemId { get; set; }
        public ProductModel Product { get; set; }
        public StoreModel Store { get; set; }
        public int Quantity { get; set; }
    }
}
