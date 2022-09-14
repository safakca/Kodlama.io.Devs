using Application.Features.ProgLang.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgLang.Queries;
public class GetListProgLangEntityQuery: IRequest<ProgLangEntityListModel>
{
    public PageRequest PageRequest { get; set; }

    public class GetListProgLangEntityQueryHandler : IRequestHandler<GetListProgLangEntityQuery, ProgLangEntityListModel>
    {
        private readonly IProgLangEntityRepository _progLangEntityRepository;
        private readonly IMapper _mapper;

        public GetListProgLangEntityQueryHandler(IProgLangEntityRepository progLangEntityRepository, IMapper mapper)
        {
            _progLangEntityRepository = progLangEntityRepository;
            _mapper = mapper;
        }

        public async Task<ProgLangEntityListModel> Handle(GetListProgLangEntityQuery request, CancellationToken cancellationToken)
        {
            IPaginate<ProgLangEntity> progLangEntities = await _progLangEntityRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);

            ProgLangEntityListModel mappedProgLangEntityListModel = _mapper.Map<ProgLangEntityListModel>(progLangEntities);

            return mappedProgLangEntityListModel;
        }
    }
}

