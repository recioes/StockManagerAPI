using StockAPI.Core.Interfaces.Repository;
using StockAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace StockAPI.Infra.Repositories
{
    public class StoreRepository : IStoreRepository
    {
        private readonly IDbConnection _connection;
        public StoreRepository(IDbConnection connection)
        {
            _connection = connection;
        }


        public async Task AddAsync(StoreModel store)
        {
            var sql = "INSERT INTO Store (Name, Address) " +
                 "VALUES (@Name, @Address)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", store.Name, DbType.String);
            parameters.Add("Address", store.Address, DbType.String);

            await _connection.ExecuteAsync(sql, parameters);
        }

        public async Task DeleteAsync(int storeId)
        {
            var sql = "DELETE FROM Store WHERE StoreId = @StoreId";
            var parameters = new DynamicParameters();
            parameters.Add("StoreId", storeId, DbType.Int32);

            await _connection.ExecuteAsync(sql, parameters);
        }

        public async Task<List<StoreModel>> SearchAllAsync(int page, int pageSize, string sortField, string sortDirection)
        {
            var validSortFields = new Dictionary<string, string>
            {
              { "name", "Name" },
              { "address", "Address" },


            };
            var orderBy = validSortFields.ContainsKey(sortField.ToLower()) ? validSortFields[sortField.ToLower()] : "Name";

            var direction = sortDirection.ToUpper() == "DESC" ? "DESC" : "ASC";

            var sql = $"SELECT * FROM Store ORDER BY {orderBy} {direction} " +
                      "OFFSET ((@page - 1) * @pageSize) ROWS FETCH NEXT @pageSize ROWS ONLY";

            var result = await _connection.QueryAsync<StoreModel>(sql, new { page, pageSize });
            return result.ToList();
        }

        public async Task<StoreModel> SearchByIdAsync(int storeId)
        {
            var sql = "SELECT * FROM Store WHERE StoreId = @StoreId";
            var result = await _connection.QueryFirstOrDefaultAsync<StoreModel>(sql, new { StoreId = storeId });
            return result;
        }

        public async Task UpdateAsync(StoreModel store)
        {
            var sql = "UPDATE Store SET Name = @Name, Address = @Address WHERE StoreId = @StoreId";
            await _connection.ExecuteAsync(sql, store);
        }
    }
    
}
