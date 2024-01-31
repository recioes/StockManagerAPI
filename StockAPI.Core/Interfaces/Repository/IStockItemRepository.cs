﻿using StockAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Core.Interfaces.Repository
{
    public interface IStockItemRepository
    {
        Task CreateStockAsync(StockItemModel stockItem);
        Task UpdateStockAsync(StockItemModel stockItem);
        Task DeleteFromStockAsync(int stockItemId);
        Task<StockItemModel> SearchByIdAsync(int stockItemId);


    }
}
