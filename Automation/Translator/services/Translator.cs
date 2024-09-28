using AutoMapper;
using Translator.interfaces;

namespace Translator.services;

internal class Translator : ITranslator<JsonSource, JsonDestination>
{
    public Task<JsonDestination> Translate(JsonSource source)
    {
        var configuration = new MapperConfiguration(
            cfg => cfg.CreateMap<JsonSource, JsonDestination>()
            .ForMember(dest => dest.Identifier, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.LastModificationDate, opt => opt.MapFrom(src => src.LastModificationDate))
            .ForPath(dest => dest.Details.Name, opt => opt.MapFrom(src => src.Name))
            .ForPath(dest => dest.Details.SubLevelIdentifiers, opt => opt.MapFrom(src => src.SubLevels.Select(l => l.Id)))
            );
        var mapper = new Mapper(configuration);
        return Task.FromResult(mapper.Map<JsonSource, JsonDestination>(source));
    }
}
