using Dapper;
using Microsoft.Extensions.Configuration;
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
    public class ProductRepository : IProductRepository
    {
        private readonly IDbConnection _connection;

        public ProductRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task AddAsync(ProductModel product)
        {
            var sql = "INSERT INTO Product (Name, Price, Description) " +
                "VALUES (@Name, @Price, @Description)";

            var parameters = new DynamicParameters();
            parameters.Add("Name", product.Name, DbType.String);
            parameters.Add("Price", product.Price, DbType.Single);
            parameters.Add("Description", product.Description, DbType.String);

            await _connection.ExecuteAsync(sql, parameters);
        }

        public async Task DeleteAsync(int id)
        {
            var sql = "DELETE FROM Product WHERE Id = @Id";
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            await _connection.ExecuteAsync(sql, parameters);
        }

        public Task<List<ProductModel>> SearchAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> SearchByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductModel> SearchByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ProductUpdateDto product)
        {
            throw new NotImplementedException();
        }
    }
}
