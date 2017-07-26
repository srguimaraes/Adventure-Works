using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using AdventureWorks.Infrastructure.Data.EF;
using AdventureWorks.Infrastructure.Data.EF.Repositories;
using AdventureWorks.Infrastructure.Domain.Interfaces.Repositories;
using AdventureWorks.Infrastructure.Domain.Interfaces.Services;
using AdventureWorks.Infrastructure.Domain.Services;

namespace AdventureWorks.Infrastructure.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, IConfigurationRoot config)
        {
            services.AddDbContext<AdventureWorks2014Context>(options =>
                   options.UseSqlServer(config.GetConnectionString("AdventureWorks2014Context")));

            services.AddSingleton(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

            //kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            //kernel.Bind<IClienteAppService>().To<ClienteAppService>();
            //kernel.Bind<IProdutoAppService>().To<ProdutoAppService>();

            //kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            //kernel.Bind<IClienteService>().To<ClienteService>();
            //kernel.Bind<IProdutoService>().To<ProdutoService>();

            //kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            //kernel.Bind<IClienteRepository>().To<ClienteRepository>();
            //kernel.Bind<IProdutoRepository>().To<ProdutoRepository>();

            services.AddSingleton<IPersonRepository, PersonRepository>();
            services.AddSingleton<IPersonService, PersonService>();
        }
    }
}
