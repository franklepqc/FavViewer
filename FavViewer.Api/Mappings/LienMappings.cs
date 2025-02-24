using AutoMapper;
using FavViewer.Api.Database;
using FavViewer.Api.Models;

namespace FavViewer.Api.Mappings
{
    public class LienMappings : Profile
    {
        public LienMappings()
        {
            // Sélection dans la BD.
            CreateMap<LienVideoDbEntity, LienVideo>()
                .ForMember(dest => dest.Id, opts => opts.MapFrom(src => src.Id))
                .ForMember(dest => dest.Titre, opts => opts.MapFrom(src => src.Titre))
                .ForMember(dest => dest.Url, opts => opts.MapFrom(src => src.Url));

            // Ajout.
            CreateMap<NouveauLienVideo, LienVideoDbEntity>()
                .ForMember(dest => dest.Id, opts => opts.Ignore())
                .ForMember(dest => dest.Titre, opts => opts.MapFrom(src => src.Titre))
                .ForMember(dest => dest.Url, opts => opts.MapFrom(src => src.Url));
        }
    }
}
