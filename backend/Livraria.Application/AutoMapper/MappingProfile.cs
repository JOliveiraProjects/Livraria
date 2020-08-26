using AutoMapper;
using Livraria.Application.ViewModels;
using Livraria.Domain.Models;

namespace Livraria.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LivrariaViewModel, LivrariaModel>()
                .ConvertUsing((source, dest) =>
                {
                    if (source == null) return null;
                    return new LivrariaModel
                    {
                        Id = source.Id,
                        Titulo = source.Titulo,
                        Autor = source.Autor
                    };
                });

            CreateMap<LivrariaModel, LivrariaViewModel>()
                .ConvertUsing((source, dest) =>
                {
                    if (source == null) return null;
                    return new LivrariaViewModel
                    {
                        Id = dest.Id,
                        Titulo = dest.Titulo,
                        Autor = dest.Autor
                    };
                });

        }
    }
}
