using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.ProgLang.Rules;
public class ProgLangEntityBusinessRules
{
    private readonly IProgLangEntityRepository _progLangEntityRepository;

    public ProgLangEntityBusinessRules(IProgLangEntityRepository progLangEntityRepository)
    {
        _progLangEntityRepository = progLangEntityRepository;
    }

    public async Task ProgLangEntityNameCanNotBeDublicatedWhenInserted(string name)
    {
        IPaginate<ProgLangEntity> result = await _progLangEntityRepository.GetListAsync(b => b.Name == name);
        if (result.Items.Any()) throw new BusinessException("ProgLangEntity name exist");
    }

    public void ProgLangShouldExistWhenRequest(ProgLangEntity progLangEntity)
    {
        if (progLangEntity == null) throw new BusinessException("Requested Programing Language does not exist");
    }
}

