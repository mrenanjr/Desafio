using Domain.Entities;
using Domain.Interfaces;
using Infra.Context;

namespace Infra.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ContextCore context) : base(context) { }
    }
}
