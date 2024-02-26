using AutoFixture;
using Kanban.Model.ApplicationDto;
using Kanban.Model.Mapper.Card;

namespace Kanban.Model.Tests.Mapper.Card
{
    public class ToRepositoryCardMapperTests
    {
        private readonly Fixture fixture;

        public ToRepositoryCardMapperTests()
        {
            fixture = new Fixture();
        }

        [Fact]
        public void ToRepository_WhenApplicationCardIsValid_ShouldMapToRepositoryProperly()
        {
            // Arrange
            var applicationCard = fixture.Create<CardDto>();

            // Act
            var repositoryCard = applicationCard.ToRepository();

            // Assert
            repositoryCard.Should().NotBeNull();
            repositoryCard.Id.Should().NotBeNull();
            repositoryCard.Id.Should().BeEquivalentTo(applicationCard.Id);
            repositoryCard.Name.Should().NotBeNull();
            repositoryCard.Name.Should().BeEquivalentTo(applicationCard.Name);
            repositoryCard.Description.Should().NotBeNull();
            repositoryCard.Description.Should().BeEquivalentTo(applicationCard.Description);
        }
    }
}
