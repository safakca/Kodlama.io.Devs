using Application.Features.ProgLang.Dtos;
using Application.Features.ProgLang.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgLang.Commands.UpdateProgLang;
public class UpdateProgLangEntityCommand : IRequest<UpdatedProgLangEntityDto>
{
    public int Id { get; set; }
    public string  Name { get; set; }

    public class UpdateProgLangEntityCommandHandler : IRequestHandler<UpdateProgLangEntityCommand, UpdatedProgLangEntityDto>
    {
        private readonly IProgLangEntityRepository _progLangEntityRepository;
        private readonly IMapper _mapper;
        private readonly ProgLangEntityBusinessRules _progLangEntityBusinessRules;

        public UpdateProgLangEntityCommandHandler(IProgLangEntityRepository progLangEntityRepository, IMapper mapper, ProgLangEntityBusinessRules progLangEntityBusinessRules)
        {
            _progLangEntityRepository = progLangEntityRepository;
            _mapper = mapper;
            _progLangEntityBusinessRules = progLangEntityBusinessRules;
        }

        public async Task<UpdatedProgLangEntityDto> Handle(UpdateProgLangEntityCommand request, CancellationToken cancellationToken)
        {
            await _progLangEntityBusinessRules.ProgLangEntityNameCanNotBeDublicatedWhenInserted(request.Name);

            var mappedProgLang = _mapper.Map<ProgLangEntity>(request);
            var updatedProgLang = await _progLangEntityRepository.UpdateAsync(mappedProgLang);
            var updatedProgLangDto = _mapper.Map<UpdatedProgLangEntityDto>(updatedProgLang);

            return updatedProgLangDto;
        }
    }
}

