using AutoFixture;
using Kanban.Model.ControllerDto.Request.Card;
using Kanban.Model.Mapper.Card;

namespace Kanban.Model.Tests.Mapper.Card
{
    public class ToApplicationCardMapperTests
    {
        private readonly Fixture fixture;

        public ToApplicationCardMapperTests()
        {
            fixture = new Fixture();
        }

        [Fact]
        public void ToApplication_WhenControllerCardIsValid_ShouldMapToApplicationProperly()
        {
            // Arrange
            var controllerCard = fixture.Create<GetCardRequestDto>();

            // Act
            var applicationCard = controllerCard.ToApplication();

            // Assert
            applicationCard.Should().NotBeNull();
            applicationCard.Id.Should().NotBeNull();
            applicationCard.Name.Should().NotBeNull();
            applicationCard.Name.Should().BeEquivalentTo(controllerCard.Name);
            applicationCard.Description.Should().NotBeNull();
            applicationCard.Description.Should().BeEquivalentTo(controllerCard.Description);
        }

        [Fact]
        public void ToApplication_WhenControllerCardIsInvalid_ShouldMapToApplicationProperly()
        {
            // Arrange
            var controllerCard = fixture.Build<GetCardRequestDto>()
                .Without(e => e.Description)
                .Without(e => e.Name)
                .Create();

            // Act
            var applicationCard = controllerCard.ToApplication();

            // Assert
            applicationCard.Should().NotBeNull();
            applicationCard.Id.Should().NotBeNull();
            applicationCard.Name.Should().Be(string.Empty);
            applicationCard.Description.Should().Be(string.Empty);
        }
    }
}
