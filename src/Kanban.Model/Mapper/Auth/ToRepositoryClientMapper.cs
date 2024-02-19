using App = Kanban.Model.ApplicationDto;
using Repo = Kanban.Model.RepositoryDto;

namespace Kanban.Model.Mapper.Auth;

public static class ToRepositoryClientMapper
{
    public static Repo.ClientDto ToRepository(this App.ClientDto client)
    {
        return new Repo.ClientDto
        {
            _id = client.Id,
            Secret = client.Secret,
        };
    }
}
