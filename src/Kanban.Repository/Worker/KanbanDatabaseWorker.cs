using Kanban.Repository.Interfaces;
using Kanban.Model.RepositoryDto;
using Kanban.Repository.Settings;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Kanban.CrossCutting;

namespace Kanban.Repository.Worker;

public class KanbanDatabaseWorker : IKanbanDatabaseWorker
{

    private readonly IMongoRepository _cardRepository;
    private readonly IMongoSettings _mongoSettings;
    public KanbanDatabaseWorker(IMongoRepository cardRepository, IMongoSettings mongoSettings)
    {
        this._cardRepository = cardRepository;
        this._mongoSettings = mongoSettings;
    }

    public async Task<Card?> GetCardByIdAsync(string id)
    {
        var filter = Builders<BsonDocument>.Filter.Eq(Constants.MongoDbId, id);

        var card = await _cardRepository.FindOne(_mongoSettings.KanbanHost.ClusterId, _mongoSettings.KanbanHost.Database, _mongoSettings.Collections.Cards, filter).ConfigureAwait(false);

        return card == null ? null : BsonSerializer.Deserialize<Card>(card.ToJson());
    }

    public async Task<List<Card>> GetAllCardsAsync()
    {
        var cards = await _cardRepository.FindMany(_mongoSettings.KanbanHost.ClusterId, _mongoSettings.KanbanHost.Database, _mongoSettings.Collections.Cards).ConfigureAwait(false);

        return BsonSerializer.Deserialize<List<Card>>(cards.ToJson());
    }

    public async Task<Card> InsertCardAsync(Card card)
    {
        await _cardRepository.Insert(_mongoSettings.KanbanHost.ClusterId, _mongoSettings.KanbanHost.Database, _mongoSettings.Collections.Cards, card.ToBsonDocument());
        return card;
    }

    public async Task<Card?> UpdateCard(Card card)
    {
        var filter = Builders<BsonDocument>.Filter.Eq(Constants.MongoDbId, card.Id);
        var update = Builders<BsonDocument>.Update
                    .Set(Constants.Name, card.Name)
                    .Set(Constants.Description, card.Description);
        var options = new UpdateOptions
        {
            IsUpsert = false
        };
        var response = await _cardRepository.Update(_mongoSettings.KanbanHost.ClusterId, _mongoSettings.KanbanHost.Database, _mongoSettings.Collections.Cards, filter, update, options);
        return response.ModifiedCount > 0 ? card : null;
    }

    public async Task<long> UpdateManyDescriptions(List<string> ids, string description)
    {
        var filter = Builders<BsonDocument>.Filter.In(Constants.MongoDbId, ids.ConvertAll(x => x));
        var update = Builders<BsonDocument>.Update
                    .Set(Constants.Description, description);
        var options = new UpdateOptions
        {
            IsUpsert = false
        };
        var response = await _cardRepository.UpdateMany(_mongoSettings.KanbanHost.ClusterId, _mongoSettings.KanbanHost.Database, _mongoSettings.Collections.Cards, filter, update, options);
        return response.ModifiedCount;
    }

    public async Task<bool> DeleteByIdAsync(string id)
    {
        var filter = Builders<BsonDocument>.Filter.Eq(Constants.MongoDbId, id);
        var result = await _cardRepository.Delete(_mongoSettings.KanbanHost.ClusterId, _mongoSettings.KanbanHost.Database, _mongoSettings.Collections.Cards, filter);
        return result.DeletedCount == 1;
    }
}
