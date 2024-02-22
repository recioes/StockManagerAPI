using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using StockAPI.Core.Interfaces.Repository;
using StockAPI.Core.Interfaces.Services;
using StockAPI.Core.Services;
using StockAPI.Infra.Repositories;
using System.Configuration;
using System.Data;

namespace StockAPI.DI
{
    public static class ServiceExtension
    {

        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {

            //Configurations
            string dbUser = Environment.GetEnvironmentVariable("DB_USER");
            string dbPassword = Environment.GetEnvironmentVariable("DB_PASSWORD");

            if (string.IsNullOrEmpty(dbUser) || string.IsNullOrEmpty(dbPassword))
            {
                throw new InvalidOperationException("As variáveis de ambiente DB_USER e/ou DB_PASSWORD não estão configuradas corretamente.");
            }

            string connectionString = configuration.GetConnectionString("DefaultConnection")
                .Replace("{DB_USER}", dbUser)
                .Replace("{DB_PASSWORD}", dbPassword);

            services.AddScoped<IDbConnection>(serviceProvider =>
                new MySqlConnection(connectionString)
            );

            //Repositories
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IStockItemRepository, StockItemRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();

            //Services
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IStockItemService, StockItemService>();
            services.AddScoped<IStoreService, StoreService>();

        }
    }
}
 