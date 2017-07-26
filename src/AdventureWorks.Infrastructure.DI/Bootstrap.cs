using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace AdventureWorks.Infrastructure.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, IConfigurationRoot config)
        {
            services.AddDbContext<AdventureWorks2014Context>(options =>
                options.UseSqlServer(config.GetConnectionString("AdventureWorks2014Context")));

            services.AddSingleton(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));
        }
    }
}
