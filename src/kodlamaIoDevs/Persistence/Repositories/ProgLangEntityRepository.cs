using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories;
public class ProgLangEntityRepository : EfRepositoryBase<ProgLangEntity, BaseDbContext>, IProgLangEntityRepository
{
    public ProgLangEntityRepository(BaseDbContext context) : base(context)
    {
    }
}

