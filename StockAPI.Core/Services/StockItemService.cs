using StockAPI.Core.Interfaces.Repository;
using StockAPI.Core.Interfaces.Services;
using StockAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Core.Services
{
    public class StockItemService : IStockItemService
    {

        private readonly IStockItemRepository _stockItemRepository;
        public StockItemService(IStockItemRepository stockItemRepository)
        {
            _stockItemRepository = stockItemRepository;
        }

        public async Task CreateStockAsync(StockItemModel stockItem)
        {
           await _stockItemRepository.CreateStockAsync(stockItem);
        }

        public async Task DeleteFromStockAsync(int stockItemId)
        {
            var existingStock = await _stockItemRepository.SearchByIdAsync(stockItemId);
            if (existingStock == null)
            {
                throw new InvalidOperationException("Estoque não existente.");
            }

            await _stockItemRepository.DeleteFromStockAsync(stockItemId);
        }

        public async Task UpdateStockAsync(StockItemModel stockItem)
        {
            var existingStock = await _stockItemRepository.SearchByIdAsync(stockItem.StockItemId);
            if (existingStock == null)
            {
                throw new KeyNotFoundException("Item de estoque não encontrado.");
            }

            if (stockItem.Quantity <= 0)
            {
                throw new ArgumentException("Quantidade inválida.");
            }

            await _stockItemRepository.UpdateStockAsync(stockItem);

        }
    }
}
