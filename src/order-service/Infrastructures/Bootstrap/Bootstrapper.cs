using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using order_service.Infrastructures.Bootstrap.DatabaseModules;

namespace order_service.Infrastructures.Bootstrap
{
    public class Bootstrapper
    {
        private readonly IServiceCollection services;
        private readonly IServiceModule[] modules;

        public Bootstrapper(IServiceCollection services, IServiceModule customDbModule = null)
        {
            this.services = services;
            modules = new[]
            {
                customDbModule ?? new SqliteDatabase(),
                new ServiceModule()
            };
        }

        public void Bootstrap()
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            
            foreach (IServiceModule serviceModule in modules)
            {
                serviceModule.Load(services);
            }
        }
    }
}