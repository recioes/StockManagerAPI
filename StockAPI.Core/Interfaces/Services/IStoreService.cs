using StockAPI.Core.DTOs;
using StockAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Core.Interfaces.Services
{
    public interface IStoreService
    {
        Task<List<StoreModel>> SearchAllAsync(int page, int pageSize, string sortField, string sortDirection);
        Task AddAsync(StoreDto store);
        Task<StoreModel> SearchByIdAsync(int storeId);
        Task UpdateAsync(int storeId, StoreDto store);
        Task DeleteAsync(int storeId);
    }
}

