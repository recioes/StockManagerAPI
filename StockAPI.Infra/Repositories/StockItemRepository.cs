using Dapper;
using StockAPI.Core.Interfaces.Repository;
using StockAPI.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockAPI.Infra.Repositories
{
    public class StockItemRepository : IStockItemRepository
    {

        private readonly IDbConnection _connection;

        public StockItemRepository(IDbConnection connection)
        {
            _connection = connection;
        }
        public async Task UpdateStockAsync(StockItemModel stockItem)
        {
            var sql = @"
             UPDATE StockItem
             SET Quantity = Quantity + @Quantity
             WHERE ProductId = @ProductId AND StoreId = @StoreId";

            var parameters = new DynamicParameters();
            parameters.Add("ProductId", stockItem.ProductId, DbType.Int32);
            parameters.Add("StoreId", stockItem.StoreId, DbType.Int32);
            parameters.Add("Quantity", stockItem.Quantity, DbType.Int32);

            await _connection.ExecuteAsync(sql, parameters);
        }

        public async Task CreateStockAsync(StockItemModel stockItem)
        {

            var sql = @"
             INSERT INTO StockItem (ProductId, StoreId, Quantity)
             VALUES (@ProductId, @StoreId, @Quantity)";

            var parameters = new DynamicParameters();
            parameters.Add("ProductId", stockItem.ProductId, DbType.Int32);
            parameters.Add("StoreId", stockItem.StoreId, DbType.Int32);
            parameters.Add("Quantity", stockItem.Quantity, DbType.Int32);

            await _connection.ExecuteAsync(sql, parameters);


        }

        public async Task DeleteFromStockAsync(int stockItemId)
        {
            var sql = "DELETE FROM StockItem WHERE StockItemId = @StockItemId";
            var parameters = new DynamicParameters();
            parameters.Add("StockItemId", stockItemId, DbType.Int32);

            await _connection.ExecuteAsync(sql, parameters);
        }

        public async Task<StockItemModel> SearchByIdAsync(int stockItemId)
        {
            var sql = "SELECT * FROM StockItem WHERE StockItemId = @StockItemId";
            return await _connection.QuerySingleOrDefaultAsync<StockItemModel>(sql, new { StockItemId = stockItemId });
        }
    }
}
