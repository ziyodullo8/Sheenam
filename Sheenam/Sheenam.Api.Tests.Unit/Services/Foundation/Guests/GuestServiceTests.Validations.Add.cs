using Sheenam.Api.Models.Foundations;
using Sheenam.Api.Models.Foundations.Exeptions;


namespace Sheenam.Api.Tests.Unit.Services.Foundation.Guests
{
    public partial class GuestServiceTests
    {
        [Fact]
        public async Task ShouldThrowValidationExceptionOnAddIfGuestlsNullAndLogItAsync()
        {
            //given
            Guest nullGuest = null;
            var nullGuestException = new NullGuestExceptions();
            var expectedGuestValidtionException=
                new GuestValidationException(nullGuestException);
            

            //when
            ValueTask<Guest> addGuestTask=
                this.guestService.AddGuestAsync(nullGuest);

            //then

            _ = await Assert.ThrowsAsync<GuestValidationException>(() =>
            addGuestTask.AsTask());
        }
    }
}
