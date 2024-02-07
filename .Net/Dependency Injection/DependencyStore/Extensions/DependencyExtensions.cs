using DependencyStore.Repositories.Contracts;
using DependencyStore.Repositories;
using Microsoft.Data.SqlClient;
using DependencyStore.Services.Contracts;
using DependencyStore.Services;

namespace DependencyStore.Extensions
{
    public static class DependencyExtensions
    {
        public static void AddSqlConnection(this IServiceCollection services, string connectionString)
        {
            services.AddScoped(x => new SqlConnection(connectionString));
        }
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IPromocodeRepository, PromoCodeRepository>();
        }
        public static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<IDeliveryFeeService, DeliveryFeeService>();
        }
    }
}
