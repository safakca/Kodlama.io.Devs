using Application.Features.ProgLang.Dtos;
using Application.Features.ProgLang.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgLang.Commands.CreateProgLang;
public class CreateProgLangEntityCommand: IRequest<CreatedProgLangEntityDto>
{
    public string Name { get; set; }

    public class CreateProgLangEntityCommandHandler : IRequestHandler<CreateProgLangEntityCommand, CreatedProgLangEntityDto>
    {
        private readonly IProgLangEntityRepository _progLangEntityRepository;
        private readonly IMapper _mapper;
        private readonly ProgLangEntityBusinessRules _progLangEntityBusinessRules;

        public CreateProgLangEntityCommandHandler(IProgLangEntityRepository progLangEntityRepository, IMapper mapper, ProgLangEntityBusinessRules progLangEntityBusinessRules)
        {
            _progLangEntityRepository = progLangEntityRepository;
            _mapper = mapper;
            _progLangEntityBusinessRules = progLangEntityBusinessRules;
        }

        public async Task<CreatedProgLangEntityDto> Handle(CreateProgLangEntityCommand request, CancellationToken cancellationToken)
        {
            await _progLangEntityBusinessRules.ProgLangEntityNameCanNotBeDublicatedWhenInserted(request.Name);

            ProgLangEntity mappedProgLangEntity = _mapper.Map<ProgLangEntity>(request);
            ProgLangEntity createdProgLangEntity = await _progLangEntityRepository.AddAsync(mappedProgLangEntity);
            CreatedProgLangEntityDto createdProgLangEntityDto = _mapper.Map<CreatedProgLangEntityDto>(createdProgLangEntity);

            return createdProgLangEntityDto;
        }
    }
}

