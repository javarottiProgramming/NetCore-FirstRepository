using JavarottiProgramming.NetCoreFirst.Domain.Contracts.Repositories;
using JavarottiProgramming.NetCoreFirst.Domain.Entities;

namespace JavarottiProgramming.NetCoreFirst.Data.EF.Repositories
{
    public class CategoriaRepositoryEF : RepositoryEF<Categoria>, ICategoriaRepository
    {
        public CategoriaRepositoryEF(StoreDataContext ctx) : base(ctx)
        {
        }
    }
}