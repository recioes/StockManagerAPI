using StockAPI.Core.DTOs;
using StockAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<List<ProductModel>> SearchAllAsync(int page, int pageSize, string sortField, string sortDirection);
        Task AddAsync(ProductDto product);
        Task<ProductModel> SearchByIdAsync(int productId);
        Task UpdateAsync(int productId, ProductDto product);
        Task DeleteAsync(int productId);
    }
}
