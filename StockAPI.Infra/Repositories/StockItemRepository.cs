using StockAPI.Core.Interfaces.Repository;
using StockAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Infra.Repositories
{
    public class StockItemRepository : IStockItemRepository
    {
        public Task AddToStockAsync(StockItemModel stockItem)
        {
            throw new NotImplementedException();
        }

        public Task CreateStockAsync(StockItemModel stockItem)
        {
            throw new NotImplementedException();
        }

        public Task DeleteFromStockAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
