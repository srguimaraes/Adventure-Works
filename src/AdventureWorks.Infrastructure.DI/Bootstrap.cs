using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AdventureWorks.Infrastructure.Data.EF;
using AdventureWorks.Infrastructure.Domain.Interfaces.Repositories;
using Microsoft.Extensions.Configuration;

namespace AdventureWorks.Infrastructure.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, IConfigurationRoot config)
        {
            services.AddDbContext<AdventureWorks2014Context>(options =>
                options.UseSqlServer(config.GetConnectionString("")));

            services.AddSingleton(typeof(IRepositoryBase<>), typeof(IRepositoryBase<>));
        }
    }
}
