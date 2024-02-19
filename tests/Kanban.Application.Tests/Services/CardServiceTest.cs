﻿namespace Kanban.Application.Tests.Services;

public class CardServiceTest
{
    private readonly Fixture fixture;
    private readonly Mock<IKanbanDatabaseWorker> worker;
    private readonly CardService cardService;

    public CardServiceTest() 
    {
        this.fixture = new Fixture();
        this.worker = new Mock<IKanbanDatabaseWorker>();
        this.cardService = new CardService(this.worker.Object);
    }

    [Fact]
    public async void GetCardById_ShouldReturnCard_WhenThereIsACardInDatabase()
    {
        // Arrange
        var card = this.fixture.Create<Model.RepositoryDto.Card>();
        this.worker.Setup(x => x.GetCardByIdAsync(card.Id))
            .ReturnsAsync(card)
            .Verifiable();

        // Act
        var result = await this.cardService.GetCardByIdAsync(card.Id);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(card.Id);
        result.Name.Should().Be(card.Name); 
        result.Description.Should().Be(card.Description);
    }

    [Fact]
    public async void GetCardById_ShouldNotReturnCard_WhenThereIsNoCardInDatabase()
    {
        // Arrange
        var card = this.fixture.Create<Model.RepositoryDto.Card>();
        this.worker.Setup(x => x.GetCardByIdAsync(card.Id))
            .ReturnsAsync(card)
            .Verifiable();
        var nonexistentCardId = "non-existent-card-id";

        // Act
        var result = await this.cardService.GetCardByIdAsync(nonexistentCardId);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be(string.Empty);
        result.Name.Should().Be(string.Empty);
        result.Description.Should().Be(string.Empty);
    }

    [Fact]
    public async void GetAllCards_ShouldReturnCards_WhenThereAreCardsInDatabase()
    {
        // Arrange
        var cards = this.fixture.Create<List<Model.RepositoryDto.Card>>();
        this.worker.Setup(x => x.GetAllCardsAsync())
            .ReturnsAsync(cards)
            .Verifiable();

        // Act
        var result = await this.cardService.GetAllCardsAsync();

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().Be(3);
        result.Select(r => r.Id).Should().Equal(cards.Select(c => c.Id));
        result.Select(r => r.Name).Should().Equal(cards.Select(c => c.Name));
        result.Select(r => r.Description).Should().Equal(cards.Select(c => c.Description));
    }

    [Fact]
    public async void GetAllCards_ShouldNotReturnCards_WhenThereAreNoCardsInDatabase()
    {
        // Arrange
        this.worker.Setup(x => x.GetAllCardsAsync())
            .Verifiable();

        // Act
        var result = await this.cardService.GetAllCardsAsync();

        // Assert
        result.Should().NotBeNull();
        result.Count.Should().Be(0);
    }
}
