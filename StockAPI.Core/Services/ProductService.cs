using StockAPI.Core.Interfaces.Repository;
using StockAPI.Core.Interfaces.Services;
using StockAPI.Core.Models;

namespace StockAPI.Core.Services
{
    public class ProductService : IProductService 
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task AddAsync(ProductModel product)
        {
            var existingProduct = await _productRepository.SearchByIdAsync(product.ProductId);
            if (existingProduct != null)
            {
                throw new InvalidOperationException("Produto já existe.");
            }

            await _productRepository.AddAsync(product);
        }

        public async Task DeleteAsync(int productId)
        {
            var existingProduct = await _productRepository.SearchByIdAsync(productId);
            if (existingProduct == null)
            {
                throw new InvalidOperationException("Produto não existente.");
            }

            await _productRepository.DeleteAsync(productId);
        }

        public async Task<List<ProductModel>> SearchAllAsync(int page, int pageSize, string sortField = "name", string sortDirection = "ASC")
        {
            return await _productRepository.SearchAllAsync(page, pageSize, sortField, sortDirection);
        }


        public async Task UpdateAsync(int productId, ProductUpdateDto product)
        {
            var existingProduct = await _productRepository.SearchByIdAsync(productId);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"Produto com ID {productId} não encontrado.");
            }

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;

            await _productRepository.UpdateAsync(existingProduct);
        }
    }
}
