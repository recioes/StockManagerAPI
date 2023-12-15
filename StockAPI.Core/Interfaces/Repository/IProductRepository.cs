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
        Task<List<ProductModel>> SearchAllAsync();
        Task<ProductModel> SearchByIdAsync(int id);
        Task<ProductModel> SearchByNameAsync(string name);
        Task AddAsync(ProductModel product);
        Task UpdateAsync(ProductUpdateDto product);
        Task DeleteAsync(int id);

    }
}
