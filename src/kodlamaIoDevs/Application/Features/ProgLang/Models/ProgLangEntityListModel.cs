using Application.Features.ProgLang.Dtos;
using Core.Persistence.Paging;

namespace Application.Features.ProgLang.Models;

public class ProgLangEntityListModel : BasePageableModel
{
    public IList<ProgLangEntityListDto> Items { get; set; }
}

