using AutoFixture;
using Kanban.Model.Mapper.Card;

namespace Kanban.Model.Tests.Mapper.Card
{
    public class ToControllerCardMapperTests
    {
        private readonly Fixture fixture;

        public ToControllerCardMapperTests()
        {
            fixture = new Fixture();
        }

        [Fact]
        public void ToController_WhenRepositoryCardIsValid_ShouldMapToControllerProperly()
        {
            // Arrange
            var repositoryCard = fixture.Create<RepositoryDto.Card>();

            // Act
            var controllerCard = repositoryCard.ToController();

            // Assert
            controllerCard.Should().NotBeNull();
            controllerCard.Id.Should().NotBeNull();
            controllerCard.Id.Should().BeEquivalentTo(repositoryCard.Id);
            controllerCard.Name.Should().NotBeNull();
            controllerCard.Name.Should().BeEquivalentTo(repositoryCard.Name);
            controllerCard.Description.Should().NotBeNull();
            controllerCard.Description.Should().BeEquivalentTo(repositoryCard.Description);
        }

        [Fact]
        public void ToControllerList_WhenRepositoryCardListIsValid_ShouldMapToControllerListProperly()
        {
            // Arrange
            var repositoryCardList = new List<RepositoryDto.Card>() 
            {
                this.fixture.Create<RepositoryDto.Card>(),
                this.fixture.Create<RepositoryDto.Card>(),
            };

            // Act
            var controllerCardList = repositoryCardList.ToControllerList();

            // Assert
            controllerCardList.Should().NotBeNull();
            controllerCardList.Count.Should().Be(2);
        }
    }
}
