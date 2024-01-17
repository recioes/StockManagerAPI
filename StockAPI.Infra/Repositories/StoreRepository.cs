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

        // Criar filtro e ordenação para pesquisar por endereço também
        public Task<List<StoreModel>> SearchAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<StoreModel>> SearchAllAsync(int page, int pageSize, string sortField, string sortDirection)
        {
            throw new NotImplementedException();
        }

        public Task<StoreModel> SearchByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(int storeId, StoreUpdateDto store)
        {
            throw new NotImplementedException();
        }
    }
}
