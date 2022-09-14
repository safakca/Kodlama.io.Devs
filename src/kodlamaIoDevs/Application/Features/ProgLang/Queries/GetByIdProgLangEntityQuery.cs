using Application.Features.ProgLang.Dtos;
using Application.Features.ProgLang.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgLang.Queries;
public class GetByIdProgLangEntityQuery : IRequest<GetByIdProgLangEntityDto>
{
    public int Id { get; set; }

    public class GetByIdProgLangEntityQueryHandler : IRequestHandler<GetByIdProgLangEntityQuery, GetByIdProgLangEntityDto>
    {
        private readonly IMapper _mapper;
        private readonly IProgLangEntityRepository _progLangEntityRepository;
        private readonly ProgLangEntityBusinessRules _progLangEntityBusinessRules;

        public GetByIdProgLangEntityQueryHandler(IMapper mapper, IProgLangEntityRepository progLangEntityRepository, ProgLangEntityBusinessRules progLangEntityBusinessRules)
        {
            _mapper = mapper;
            _progLangEntityRepository = progLangEntityRepository;
            _progLangEntityBusinessRules = progLangEntityBusinessRules;
        }

        public async Task<GetByIdProgLangEntityDto> Handle(GetByIdProgLangEntityQuery request, CancellationToken cancellationToken)
        {
            ProgLangEntity progLangEntity = await _progLangEntityRepository.GetAsync(x => x.Id == request.Id);

            _progLangEntityBusinessRules.ProgLangShouldExistWhenRequest(progLangEntity);

            GetByIdProgLangEntityDto getByIdProgLangEntityDto = _mapper.Map<GetByIdProgLangEntityDto>(progLangEntity);

            return getByIdProgLangEntityDto;
        }
    }
}

