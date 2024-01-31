using Dapper;
using StockAPI.Core.Interfaces.Repository;
using StockAPI.Core.Models;
using System.Data;

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

        public async Task DeleteAsync(int productId)
        {
            var sql = "DELETE FROM Product WHERE ProductId = @ProductId";
            var parameters = new DynamicParameters();
            parameters.Add("ProductId", productId, DbType.Int32);

            await _connection.ExecuteAsync(sql, parameters);
        }

        public async Task<List<ProductModel>> SearchAllAsync(int page, int pageSize, string sortField = "name", string sortDirection = "ASC")
        {
            var validSortFields = new Dictionary<string, string>
            {
              { "name", "Name" },
              { "price", "Price" },
              { "description", "Description" },
              { "productId", "ProductId" },

            };
            var orderBy = validSortFields.ContainsKey(sortField.ToLower()) ? validSortFields[sortField.ToLower()] : "Name";

            var direction = sortDirection.ToUpper() == "DESC" ? "DESC" : "ASC";

            var sql = $"SELECT * FROM Product ORDER BY {orderBy} {direction} " +
                      "OFFSET ((@page - 1) * @pageSize) ROWS FETCH NEXT @pageSize ROWS ONLY";

            var result = await _connection.QueryAsync<ProductModel>(sql, new { page, pageSize });
            return result.ToList();
        }


        public async Task<ProductModel> SearchByIdAsync(int productId)
        {
            var sql = "SELECT * FROM Product WHERE ProductId = @ProductId";
            var result = await _connection.QueryFirstOrDefaultAsync<ProductModel>(sql, new { ProductId = productId });
            return result;
        }

        public async Task UpdateAsync(ProductModel product)
        {
            var sql = "UPDATE Product SET Name = @Name, Price = @Price, Description = @Description WHERE ProductId = @ProductId";
            await _connection.ExecuteAsync(sql, product);
        }





    }
}
