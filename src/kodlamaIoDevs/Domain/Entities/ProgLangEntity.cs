using Core.Persistence.Repositories;

namespace Domain.Entities;
public class ProgLangEntity : Entity
{
    public string Name { get; set; }
    public ProgLangEntity()
    {

    }
    public ProgLangEntity(int id, string name) :this()
    {
        Id = id;
        Name = name;
    }
}

