using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Mmu.Mlazh.LanguageService.Translations.Areas.Models;

namespace Mmu.Mlazh.LanguageService.Translations.Infrastructure.WebApi.Dtos.Profiles
{
    public class TranslationRequestDtoProfile : Profile
    {
        public TranslationRequestDtoProfile()
        {
            CreateMap<TargetedSourceLanguageTranslationRequest, TranslationRequestDto>()
                .ForMember(
                    d => d.Entries,
                    c => c.MapFrom(
                        f => f.TextParts.Select(
                            g => new TranslationRequestEntryDto
                            {
                                Text = g
                            }).ToList()))
                .ForMember(d => d.SourceLanguageCodes, c => c.MapFrom(f => f.SourceLanguageCodes))
                .ForMember(d => d.TargetLanguageCodes, c => c.MapFrom(f => f.TargetLanguageCodes));

            CreateMap<AutoDetectLanguageTranslationRequest, TranslationRequestDto>()
                .ForMember(
                    d => d.Entries,
                    c => c.MapFrom(
                        f => f.TextParts.Select(
                            g => new TranslationRequestEntryDto
                            {
                                Text = g
                            }).ToList()))
                .ForMember(d => d.SourceLanguageCodes, c => c.UseValue(new List<string>()))
                .ForMember(d => d.TargetLanguageCodes, c => c.MapFrom(f => f.TargetLanguageCodes));
        }
    }
}