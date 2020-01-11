using FN.Store.Domain.Contracts.Repositories;
using FN.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FN.Store.Data.EF.Repositories
{
    public class ProdutoRepositoryEF : RepositoryEF<Produto>, IProdutoRepository
    {
        public ProdutoRepositoryEF(StoreDataContext ctx) : base(ctx)
        {
        }

        public async Task<IEnumerable<Produto>> GetAllWithCategoryAsync()
        {
            return await _db.Include(x => x.Categoria)
                        .ToListAsync();
        }

        public async Task<Produto> GetByIdWithCategoryAsync(int id)
        {
            return await _db.Include(x => x.Categoria)
                       .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Produto>> GetByName(string name)
        {
            return await _db.Where(x => x.Nome.Contains(name))
                        .ToListAsync();
        }
    }
}
