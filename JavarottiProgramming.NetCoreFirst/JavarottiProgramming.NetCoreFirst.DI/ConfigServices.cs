using JavarottiProgramming.NetCoreFirst.Data.EF;
using JavarottiProgramming.NetCoreFirst.Data.EF.Repositories;
using JavarottiProgramming.NetCoreFirst.Domain.Contracts.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace JavarottiProgramming.NetCoreFirst.DI
{
    public static class ConfigServices
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<StoreDataContext>();
            services.AddTransient<IProdutoRepository, ProdutoRepositoryEF>();
            services.AddTransient<ICategoriaRepository, CategoriaRepositoryEF>();
        }
    }
}