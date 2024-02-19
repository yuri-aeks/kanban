using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace Kanban.Model.RepositoryDto;

public class Card
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
}
