using Desafio.Models;

namespace Desafio.Application.Interfaces
{
    public interface IProdutoService
    {
        Task<List<ProdutoViewModel>> GetAllAsync();
        Task<ProdutoViewModel> GetByIdAsync(long id);
        Task<ProdutoViewModel> CreateAsync(ProdutoViewModel viewModel);
        Task UpdateAsync(long id, ProdutoViewModel viewModel);
        Task DeleteAsync(long id);
        Task DeleteAllAsync();
    }
}
