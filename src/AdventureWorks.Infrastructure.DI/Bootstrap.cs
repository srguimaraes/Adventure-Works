using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AdventureWorks.Infrastructure.Data.EF;
using AdventureWorks.Infrastructure.Data.EF.Repositories;
using AdventureWorks.Infrastructure.Domain.Interfaces.Repositories;
using AdventureWorks.Infrastructure.Domain.Interfaces.Services;
using AdventureWorks.Infrastructure.Domain.Services;
using AdventureWorks.Application.Interfaces;
using AdventureWorks.Application;

namespace AdventureWorks.Infrastructure.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, IConfigurationRoot config)
        {
            services.AddDbContext<AdventureWorks2014Context>(options =>
                   options.UseSqlServer(config.GetConnectionString("AdventureWorks2014Context")));
            
            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddSingleton<IPersonService, PersonService>();
            services.AddSingleton<IPersonAppService, PersonAppService>();
        }
    }
}
