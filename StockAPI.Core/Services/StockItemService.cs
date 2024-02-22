using Org.BouncyCastle.Asn1.Ocsp;
using StockAPI.Core.DTOs;
using StockAPI.Core.Interfaces.Repository;
using StockAPI.Core.Interfaces.Services;
using StockAPI.Core.Models;

namespace StockAPI.Core.Services
{
    public class StockItemService : IStockItemService
    {

        private readonly IStockItemRepository _stockItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IStoreRepository _storeRepository;

        public StockItemService(IStockItemRepository stockItemRepository, IProductRepository productRepository, IStoreRepository storeRepository)
        {
            _stockItemRepository = stockItemRepository;
            _productRepository = productRepository;
            _storeRepository = storeRepository;
        }

        public async Task CreateStockAsync(StockItemDto stockItem)

        {

            var StockItemModel = new StockItemModel
            {
                ProductId = stockItem.ProductId,
                StoreId = stockItem.StoreId,
                Quantity = stockItem.Quantity
            };

            if (stockItem.Quantity <= 0)
            {
                throw new ArgumentException("Quantidade inválida.");
            }

            // Verifica se o produto existe
            var product = await _productRepository.SearchByIdAsync(stockItem.ProductId);
            if (product == null)
            {
                throw new InvalidOperationException($"Produto com ID {stockItem.ProductId} não encontrado.");
            }

            // Verifica se a loja existe
            var store = await _storeRepository.SearchByIdAsync(stockItem.StoreId);
            if (store == null)
            {
                throw new InvalidOperationException($"Loja com ID {stockItem.StoreId} não encontrada.");
            }

            await _stockItemRepository.CreateStockAsync(StockItemModel);
        }

        public async Task DeleteStockAsync(int stockItemId)
        {
            var existingStock = await _stockItemRepository.SearchByIdAsync(stockItemId);
            if (existingStock == null)
            {
                throw new InvalidOperationException("Estoque não existente.");
            }

            await _stockItemRepository.DeleteStockAsync(stockItemId);
        }

        public async Task AddMoreToStockAsync(int stockItemId, StockItemDto stockItem)
        {
            if (stockItem.Quantity <= 0)
            {
                throw new ArgumentException("Quantidade inválida.");
            }

            var existingStock = await _stockItemRepository.SearchByIdAsync(stockItemId);
            if (existingStock == null)
            {
                throw new KeyNotFoundException("Item de estoque não encontrado.");
            }
            existingStock.Quantity = stockItem.Quantity;

            await _stockItemRepository.AddMoreToStockAsync(existingStock);

        }

        public async Task LowerStockQuantityAsync(int stockItemId, StockItemDto stockItem)
        {
            if (stockItem.Quantity <= 0)
            {
                throw new ArgumentException("Quantidade inválida.");
            }

            var existingStock = await _stockItemRepository.SearchByIdAsync(stockItemId);
            if (existingStock == null)
            {
                throw new KeyNotFoundException("Item de estoque não encontrado.");
            }
            existingStock.Quantity = stockItem.Quantity;

            await _stockItemRepository.LowerStockQuantityAsync(existingStock);

        }


    }
}
