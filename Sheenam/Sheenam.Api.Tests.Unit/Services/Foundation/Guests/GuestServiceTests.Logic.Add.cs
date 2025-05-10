//================================
//Copyright (C) Coalitionof Good-Hearted Engineers
//Free To Use Comfort and Peace
//================================


using FluentAssertions;
using Moq;
using Force.DeepCloner;
using Sheenam.Api.Models.Foundations;


namespace Sheenam.Api.Tests.Unit.Services.Foundation.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]
        public async Task ShouldAddGuestInWrongWayAsync()
        {
            //Arrange
            Guest rondomGuest = new Guest
            {
                Id = Guid.NewGuid(),

                FirstName = "Alex",
                LastName = "Doe",
                Address = "Brooks Str. #12",
                DateOfBrith = new DateTimeOffset(),
                Email = "randim@gmail.ru",
                Gender = GenderType.Male,
                PhoneNumber = "12345",
            };

            _ = this.storageBrokerMock.Setup(broker =>
            broker.InsertGuestAsync(rondomGuest))
                .ReturnsAsync(rondomGuest);
            //Act
            Guest actual = await this.guestService.AddGuestAsync(rondomGuest);
            //Assert
            _ = actual.Should().BeEquivalentTo(rondomGuest);
        }

        [Fact]
        public async Task ShouldAddGuestAsync()
        {
            //given
            Guest randomGuest = CreateRandomGuest();
            Guest inputGuest = randomGuest;
            Guest storageBroker=  inputGuest;
            Guest expectedGuest= storageBroker.DeepClone();

            _ = this.storageBrokerMock.Setup(broker =>
            broker.InsertGuestAsync(inputGuest))
                .ReturnsAsync(storageBroker);

            //when
            Guest actualGuest =
                await this.guestService.AddGuestAsync(inputGuest);

            //then
            _ = actualGuest.Should().BeEquivalentTo(expectedGuest);

            this.storageBrokerMock.Verify(broker =>
            broker.InsertGuestAsync(inputGuest),
            Times.Once);

            this.storageBrokerMock.VerifyNoOtherCalls();
        }
    }
}
