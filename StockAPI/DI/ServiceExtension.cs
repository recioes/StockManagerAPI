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
            services.AddScoped<IDbConnection>(serviceProvider =>
                new MySqlConnection(configuration.GetConnectionString("DefaultConnection"))
            );

            //Repositories
            services.AddSingleton<IProductRepository, ProductRepository>();
            services.AddSingleton<IStockItemRepository, StockItemRepository>();
            services.AddSingleton<IStoreRepository, StoreRepository>();

            //Services
            services.AddSingleton<IProductService, ProductService>();

        }
    }
}
 