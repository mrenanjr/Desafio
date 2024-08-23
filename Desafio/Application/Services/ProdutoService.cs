using AutoMapper;
using Desafio.Application.Common;
using Desafio.Application.Interfaces;
using Desafio.Models;
using Domain.Entities;
using Domain.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Application.Services
{
    public class ProdutoService : BaseService<ProdutoService>, IProdutoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMapper _mapper;

        public ProdutoService(ILogger<ProdutoService> logger, IProdutoRepository produtoRepository, IMapper mapper) : base(logger)
        {
            _produtoRepository = produtoRepository;
            _mapper = mapper;
        }

        public async Task<List<ProdutoViewModel>> GetAllAsync()
        {
            var produtos = await _produtoRepository.GetAllAsync();
            return produtos.Select(a => _mapper.Map<ProdutoViewModel>(a)).ToList();
        }

        public async Task<ProdutoViewModel> GetByIdAsync(long id)
        {
            var produto = await _produtoRepository.GetAsync(x => x.Id == id);

            return _mapper.Map<ProdutoViewModel>(produto);
        }

        public async Task<ProdutoViewModel> CreateAsync(ProdutoViewModel viewModel)
        {
            var produto = _mapper.Map<Produto>(viewModel);
            var newProduto = await _produtoRepository.CreateAsync(produto);

            return _mapper.Map<ProdutoViewModel>(newProduto);
        }

        public async Task UpdateAsync(long id, ProdutoViewModel viewModel)
        {
            var produto = _produtoRepository.Find(x => x.Id == id);

            _mapper.Map(viewModel, produto);

            await _produtoRepository.UpdateAsync(produto);
        }

        public async Task DeleteAsync(long id)
        {
            var produto = _produtoRepository.Find(x => x.Id == id);

            await _produtoRepository.DeleteAsync(produto);
        }

        public async Task DeleteAllAsync() => await _produtoRepository.DeleteAllAsync();
    }
}