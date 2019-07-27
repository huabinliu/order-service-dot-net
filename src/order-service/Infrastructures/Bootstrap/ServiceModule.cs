using Microsoft.Extensions.DependencyInjection;
using order_service.Applications;
using order_service.Domains;
using order_service.Infrastructures.Repositories;

namespace order_service.Infrastructures.Bootstrap
{
    public class ServiceModule : IServiceModule
    {
        public void Load(IServiceCollection services)
        {
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IStackItemRepository, StackItemRepository>();
            services.AddScoped<OrderService>();
        }
    }
}