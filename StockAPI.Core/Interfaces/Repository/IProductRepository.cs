using StockAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Core.Interfaces.Repository
{
    public interface IProductRepository
    {
        Task<List<ProductModel>> SearchAllAsync(int page, int pageSize, string sortField, string sortDirection);
        Task<ProductModel> SearchByIdAsync(int ProductId);
        Task AddAsync(ProductModel product);
        Task UpdateAsync(int productId, ProductUpdateDto product);
        Task DeleteAsync(int ProductId);

    }
}
