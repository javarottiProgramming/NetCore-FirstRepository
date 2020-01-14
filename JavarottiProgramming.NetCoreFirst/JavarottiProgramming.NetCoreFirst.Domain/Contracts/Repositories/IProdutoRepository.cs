using JavarottiProgramming.NetCoreFirst.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JavarottiProgramming.NetCoreFirst.Domain.Contracts.Repositories
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetByName(string name);
        Task<IEnumerable<Produto>> GetAllWithCategoryAsync();
        Task<Produto> GetByIdWithCategoryAsync(int id);
    }
}