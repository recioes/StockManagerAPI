using StockAPI.Core.DTOs;
using StockAPI.Core.Interfaces.Repository;
using StockAPI.Core.Interfaces.Services;
using StockAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Core.Services
{
    public class StoreService : IStoreService
    {
        private readonly IStoreRepository _storeRepository;

        public StoreService(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }

        public async Task AddAsync(StoreDto store)
        {
            var storeModel = new StoreModel
            {
                Name = store.Name,
                Address = store.Address,
            };
            await _storeRepository.AddAsync(storeModel);
        }

       public async Task<StoreModel> SearchByIdAsync(int storeId)
        {
            var existingStore = await _storeRepository.SearchByIdAsync(storeId);
            if (existingStore == null)
            {
                throw new InvalidOperationException($"Loja com ID {storeId} não encontrada.");
            }

            return existingStore;

        }

        public async Task DeleteAsync(int storeId)
        {
            var existingStore = await _storeRepository.SearchByIdAsync(storeId);
            if (existingStore == null)
            {
                throw new InvalidOperationException($"loja não encontrada.");
            }

            await _storeRepository.DeleteAsync(storeId);
        }

        public async Task<List<StoreModel>> SearchAllAsync(int page, int pageSize, string sortField, string sortDirection)
        {
            return await _storeRepository.SearchAllAsync(page, pageSize, sortField, sortDirection);
        }

        public async Task UpdateAsync(int storeId, StoreDto store)
        {
            var existingStore = await _storeRepository.SearchByIdAsync(storeId);
            if (existingStore == null)
            {
                throw new KeyNotFoundException($"Loja com ID {storeId} não encontrada.");
            }

            existingStore.Name = store.Name;
            existingStore.Address = store.Address;

            await _storeRepository.UpdateAsync(existingStore);
        }
    }
}
