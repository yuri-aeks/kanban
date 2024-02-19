using App = Kanban.Model.ApplicationDto;
using Repo = Kanban.Model.RepositoryDto;

namespace Kanban.Model.Mapper.Auth;

public static class ToRepositoryClientMapper
{
    public static Repo.Client ToRepository(this App.ClientDto client)
    {
        return new Repo.Client
        {
            Id = client.Id,
            Secret = client.Secret,
        };
    }
}
