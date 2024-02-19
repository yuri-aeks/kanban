using Kanban.Repository.Repositories;
using Kanban.Repository.Settings;
using Kanban.Repository.Worker;
using MongoDB.Driver;

namespace Kanban.Infra.Tests.Repositories;

public class MongoRepositoryTestsSetup : IDisposable
{
    public readonly KanbanDatabaseWorker cardWorker;
    public readonly AuthDatabaseWorker authWorker;
    private readonly MongoRepository _repository;
    private readonly MongoSettings _setting;
    private readonly IEnumerable<IMongoClient> _clients;

    public MongoRepositoryTestsSetup()
    {
        _setting = new MongoSettings
        {
            KanbanHost = new MongoHost
            {
                Host = "mongodb://localhost:27017",
                Database = "test",
                ClusterId = 0,
            },
            Collections = new Collections
            {
                Cards = "cards",
                Clients = "clients",
            },
        };
        var kanbanSettings = MongoClientSettings.FromConnectionString(_setting.KanbanHost.Host);;
        kanbanSettings.SslSettings = new SslSettings { EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12 };
        var client = new MongoClient(kanbanSettings);
        _clients = new List<IMongoClient> { client };
        _repository = new MongoRepository(_clients);

        this.cardWorker = new KanbanDatabaseWorker(_repository, _setting);
        this.authWorker = new AuthDatabaseWorker(_repository, _setting);
        this.Dispose();
        this.Migrate();
    }

    public void Dispose()
    {
        var collection = _clients.ElementAt(_setting.KanbanHost.ClusterId).GetDatabase(_setting.KanbanHost.Database).GetCollection<Model.RepositoryDto.Card>(_setting.Collections.Cards);
        collection.DeleteMany(Builders<Model.RepositoryDto.Card>.Filter.Empty);

        var clientCollection = _clients.ElementAt(_setting.KanbanHost.ClusterId).GetDatabase(_setting.KanbanHost.Database).GetCollection<Model.RepositoryDto.Client>(_setting.Collections.Clients);
        clientCollection.DeleteMany(Builders<Model.RepositoryDto.Client>.Filter.Empty);
    }

    public void Migrate()
    {
        var cardCollection = _clients.ElementAt(_setting.KanbanHost.ClusterId).GetDatabase(_setting.KanbanHost.Database).GetCollection<Model.RepositoryDto.Card>(_setting.Collections.Cards);
        var cardOne = JsonConvert.DeserializeObject<Model.RepositoryDto.Card>(Mocks.SampleMockOne);
        var cardTwo = JsonConvert.DeserializeObject<Model.RepositoryDto.Card>(Mocks.SampleMockTwo);
        var cardThree = JsonConvert.DeserializeObject<Model.RepositoryDto.Card>(Mocks.SampleMockThree);
        var list = new List<Model.RepositoryDto.Card> { cardOne, cardTwo, cardThree };
        cardCollection.InsertMany(list);
        var clientCollection = _clients.ElementAt(_setting.KanbanHost.ClusterId).GetDatabase(_setting.KanbanHost.Database).GetCollection<Model.RepositoryDto.Client>(_setting.Collections.Clients);
        var client = JsonConvert.DeserializeObject<Model.RepositoryDto.Client>(Mocks.ClientMock);
        clientCollection.InsertOne(client);
    }
}
