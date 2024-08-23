using AutoMapper;
using Desafio.Models;
using Domain.Entities;

namespace Desafio.Application.AutoMapper
{
    public class AutoMapperSetup : Profile
    {
        public AutoMapperSetup()
        {
            #region Primitive types

            CreateMap<int?, int>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<string?, Guid>().ConvertUsing((src, dest) => src != null ? new Guid(src) : dest);
            CreateMap<string?, string>().ConvertUsing((src, dest) => src ?? dest);

            #endregion

            #region ViewModelToDomain

            CreateMap<ProdutoViewModel, Produto>();

            #endregion

            #region DomainToModelView

            CreateMap<Produto, ProdutoViewModel>();

            #endregion
        }
    }
}
