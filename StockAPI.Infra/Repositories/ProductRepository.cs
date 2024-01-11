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

        // Criar filtro pra filtrar por nome tbm
        public async Task<List<ProductModel>> SearchAllAsync()
        {
            var sql = "SELECT * FROM Product";
            var result = await _connection.QueryAsync<ProductModel>(sql);
            return result.ToList();
        }

        public async Task<ProductModel> SearchByIdAsync(int id)
        {
            var sql = "SELECT * FROM Product WHERE Id = @Id";
            var result = await _connection.QueryFirstOrDefaultAsync<ProductModel>(sql, new { Id = id });
            return result;
        }

        public async Task UpdateAsync(int productId, ProductUpdateDto product)
        {
            var sql = "UPDATE Product SET Name = @Name, Price = @Price, Description = @Description WHERE ProductId = @ProductId";
            await _connection.ExecuteAsync(sql, new { product.Name, product.Price, product.Description, ProductId = productId });
        }




    }
}
