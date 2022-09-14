using Application.Features.ProgLang.Commands.CreateProgLang;
using Application.Features.ProgLang.Commands.DeleteProgLang;
using Application.Features.ProgLang.Commands.UpdateProgLang;
using Application.Features.ProgLang.Dtos;
using Application.Features.ProgLang.Models;
using Application.Features.ProgLang.Queries;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgLang.Profiles;
public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ProgLangEntity, CreatedProgLangEntityDto>().ReverseMap();
        CreateMap<ProgLangEntity, CreateProgLangEntityCommand>().ReverseMap();
        CreateMap<ProgLangEntity, DeletedProgLangEntityDto>().ReverseMap();
        CreateMap<ProgLangEntity, DeleteProgLangEntityCommand>().ReverseMap();
        CreateMap<ProgLangEntity, UpdatedProgLangEntityDto>().ReverseMap();
        CreateMap<ProgLangEntity, UpdateProgLangEntityCommand>().ReverseMap();
        CreateMap<IPaginate<ProgLangEntity>, ProgLangEntityListModel>().ReverseMap();
        CreateMap<ProgLangEntity, ProgLangEntityListDto>().ReverseMap();
        CreateMap<ProgLangEntity, GetByIdProgLangEntityDto>().ReverseMap();
        CreateMap<ProgLangEntity, GetByIdProgLangEntityQuery>().ReverseMap();
    }
}

