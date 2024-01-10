using StockAPI.Core.Interfaces.Repository;
using StockAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Infra.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        public Task AddAsync(StoreModel store)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<StoreModel>> SearchAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<StoreModel> SearchByAdressAsync(string address)
        {
            throw new NotImplementedException();
        }

        public Task<StoreModel> SearchByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(StoreUpdateDto store)
        {
            throw new NotImplementedException();
        }
    }
}
