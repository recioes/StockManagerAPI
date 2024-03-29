﻿using StockAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Core.Interfaces.Repository
{
    public interface IStoreRepository
    {
        Task<List<StoreModel>> SearchAllAsync(int page, int pageSize, string sortField, string sortDirection);
        Task<StoreModel> SearchByIdAsync(int storeId);
        Task AddAsync(StoreModel store);
        Task UpdateAsync(StoreModel store);
        Task DeleteAsync(int storeId);
    }
}
