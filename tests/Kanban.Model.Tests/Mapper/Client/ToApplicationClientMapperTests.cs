using AutoFixture;
using Kanban.Model.ControllerDto.Request.Auth;
using Kanban.Model.Mapper.Auth;

namespace Kanban.Model.Tests.Mapper.Client
{
    public class ToApplicationClientMapperTests
    {
        private readonly Fixture fixture;

        public ToApplicationClientMapperTests()
        {
            fixture = new Fixture();
        }

        [Fact]
        public void ToApplication_WhenControllerCardIsValid_ShouldMapToApplicationProperly()
        {
            // Arrange
            var controllerClient = fixture.Create<CreateClientRequestDto>();

            // Act
            var applicationClient = controllerClient.ToApplication();

            // Assert
            applicationClient.Should().NotBeNull();
            applicationClient.Id.Should().NotBeNull();
            applicationClient.Id.Should().BeEquivalentTo(controllerClient.Id);
            applicationClient.Secret.Should().NotBeNull();
            applicationClient.Secret.Should().BeEquivalentTo(controllerClient.Secret);
        }
    }
}
