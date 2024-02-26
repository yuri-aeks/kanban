namespace Kanban.Infra.Tests.Repositories;

public class ClientRepositoryTests : MongoRepositoryTestsSetup
{

    [Fact]
    public async Task GetById_ShouldReturnCard_WhenValidCardIsSearched()
    {
        // Act
        var response = await this.cardWorker.GetCardByIdAsync(Mocks.SampleMockOneId);

        // Assert
        response.Id.Should().Be(Mocks.SampleMockOneId);
    }


    [Fact]
    public async Task GetById_ShouldNotReturnCard_WhenInvalidCardIsSearched()
    {
        // Act
        var response = await this.cardWorker.GetCardByIdAsync(ObjectId.GenerateNewId().ToString());

        // Assert
        response.Should().BeNull();
    }

    [Fact]
    public async Task GetAll_ShouldReturnCards_WhenThereAreCardsInDatabase()
    {
        // Act
        var response = await this.cardWorker.GetAllCardsAsync();

        // Assert
        response.Should().NotBeNull();
        response.Count.Should().Be(3);
    }

    [Fact]
    public async Task GetAll_ShouldReturnNoCards_WhenThereAreNoCardsInDatabase()
    {
        // Assert
        this.Dispose();

        // Act
        var response = await this.cardWorker.GetAllCardsAsync();

        // Assert
        response.Should().NotBeNull();
        response.Count.Should().Be(0);
    }

    [Fact]
    public async Task Insert_ShouldInsertCard_WhenCardIsGiven()
    {
        // Arrange
        var card = JsonConvert.DeserializeObject<Model.RepositoryDto.Card>(Mocks.InsertMockObject);

        // Act
        var response = await this.cardWorker.InsertCardAsync(card);

        // Assert
        response.Should().NotBeNull();
        response.Id.Should().Be(card.Id);
    }

    [Fact]
    public async Task Update_ShouldUpdateCard_WhenValidCardIsGiven()
    {
        // Arrange
        var card = JsonConvert.DeserializeObject<Model.RepositoryDto.Card>(Mocks.UpdateMockObject);
        await this.cardWorker.InsertCardAsync(card);
        card.Name = "New Name";

        // Act
        var response = await this.cardWorker.UpdateCard(card);
        var updatedCard = await this.cardWorker.GetCardByIdAsync(card.Id);
        // Assert
        response.Should().NotBeNull();
        response.Id.Should().Be(card.Id);
        updatedCard.Name.Should().Be("New Name");
    }

    [Fact]
    public async Task Update_ShouldNotUpdateCard_WhenNonExistingCardIsGiven()
    {
        // Arrange
        var card = JsonConvert.DeserializeObject<Model.RepositoryDto.Card>(Mocks.NonexistingMockObject);

        // Act
        var response = await this.cardWorker.UpdateCard(card);

        // Assert
        response.Should().BeNull();
    }

    [Fact]
    public async Task UpdateMany_ShouldUpdateManyCardDescriptions_WhenValidCardIdsAreGiven()
    {
        // Arrange
        var ids = new List<string> { Mocks.SampleMockOneId, Mocks.SampleMockTwoId };
        var newDescription = "New Description";

        // Act
        var response = await this.cardWorker.UpdateManyDescriptions(ids, newDescription);

        // Assert
        response.Should().Be(2);
    }

    [Fact]
    public async Task Delete_ShouldDeleteCard_WhenValidCardIdIsGiven()
    {
        // Arrange
        var id = Mocks.SampleMockOneId;

        // Act
        var response = await this.cardWorker.DeleteByIdAsync(id);
        var deletedCard = await this.cardWorker.GetCardByIdAsync(id);
        var remainingCards = await this.cardWorker.GetAllCardsAsync();

        // Assert
        response.Should().Be(true);
        deletedCard.Should().BeNull();
        remainingCards.Count.Should().Be(2);
        var card = JsonConvert.DeserializeObject<Model.RepositoryDto.Card>(Mocks.SampleMockOne);
        await this.cardWorker.InsertCardAsync(card);
    }

    [Fact]
    public async Task Delete_ShouldNotDeleteCard_WhenUnexistingCardIdIsGiven()
    {
        // Arrange
        var id = Mocks.NonExistingCardId;

        // Act
        var response = await this.cardWorker.DeleteByIdAsync(id);
        var deletedCard = await this.cardWorker.GetCardByIdAsync(id);
        var remainingCards = await this.cardWorker.GetAllCardsAsync();
        // Assert
        response.Should().Be(false);
        deletedCard.Should().BeNull();
        remainingCards.Count.Should().Be(3);
    }

    [Fact]
    public async Task GetById_ShouldGetClient_WhenValidIdAreSend()
    {
        // Act
        var result = await this.authWorker.GetClientById("client");

        // Assert
        result.Should().NotBeNull();
        result.Secret.Should().Be("secret");
    }

    [Fact]
    public async Task GetById_ShouldNotGetClient_WhenInvalidIdAreSend()
    {
        // Act
        var result = await this.authWorker.GetClientById("fake_client");

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task Register_ShouldRegisterClient_WhenValidCredentialsAreSend()
    {
        // Arrange
        var client = JsonConvert.DeserializeObject<Model.RepositoryDto.Client>(Mocks.NewClientMock);

        // Act
        await this.authWorker.RegisterClient(client);
        var result = await this.authWorker.GetClientById(client.Id);

        // Assert
        result.Should().NotBeNull();
        result.Secret.Should().Be("newsecret");
    }
}
