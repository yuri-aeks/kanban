using MongoDB.Bson.Serialization.Attributes;

namespace Kanban.Model.RepositoryDto;

public class Client
{
    [BsonId]
    public string Id { get; set; } = string.Empty;

    public string Secret { get; set; } = string.Empty;
}
