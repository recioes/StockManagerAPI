using StockAPI.Core.DTOs;
using StockAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Core.Interfaces.Services
{
    public interface IStockItemService
    {
        Task CreateStockAsync(StockItemDto stockItem);
        Task AddMoreToStockAsync(int stockItemId, StockItemDto stockItem);
        Task DeleteStockAsync(int stockItemId);
        Task LowerStockQuantityAsync(int stockItemId, StockItemDto stockItem);
    }
}
