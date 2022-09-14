using Application.Features.ProgLang.Dtos;
using Application.Features.ProgLang.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features.ProgLang.Commands.DeleteProgLang;
public class DeleteProgLangEntityCommand : IRequest<DeletedProgLangEntityDto>
{
    public int Id { get; set; }


    public class DeleteProgLangEntityCommandHandler : IRequestHandler<DeleteProgLangEntityCommand, DeletedProgLangEntityDto>
    {
        private readonly IMapper _mapper;
        private readonly IProgLangEntityRepository _progLangEntityRepository;
        private readonly ProgLangEntityBusinessRules _progLangEntityBusinessRules;

        public DeleteProgLangEntityCommandHandler(IMapper mapper, IProgLangEntityRepository progLangEntityRepository, ProgLangEntityBusinessRules progLangEntityBusinessRules)
        {
            _mapper = mapper;
            _progLangEntityRepository = progLangEntityRepository;
            _progLangEntityBusinessRules = progLangEntityBusinessRules;
        }

        public async Task<DeletedProgLangEntityDto> Handle(DeleteProgLangEntityCommand request, CancellationToken cancellationToken)
        {
            var progLang = await _progLangEntityRepository.GetAsync(x => x.Id == request.Id);

            _progLangEntityBusinessRules.ProgLangShouldExistWhenRequest(progLang);

            var deletedProgLang = await _progLangEntityRepository.DeleteAsync(progLang);
            var mappedDeletedProgLangDto = _mapper.Map<DeletedProgLangEntityDto>(deletedProgLang);

            return mappedDeletedProgLangDto;
        }
    }
}
