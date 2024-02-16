using App = Kanban.Model.ApplicationDto;
using Repo = Kanban.Model.RepositoryDto;

namespace Kanban.Model.Mapper.Request.Auth;

public static class ToDatabaseClientMapper 
{
    public static Repo.ClientDto ToDatabase(this App.ClientDto client)
    {
        return new Repo.ClientDto
        {
            _id = client.Id,
            Secret = client.Secret,
        };
    }
}
