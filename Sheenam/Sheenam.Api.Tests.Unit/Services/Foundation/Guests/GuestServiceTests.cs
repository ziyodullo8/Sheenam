//================================
//Copyright (C) Coalitionof Good-Hearted Engineers
//Free To Use Comfort and Peace
//================================


using Moq;
using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations;
using Sheenam.Api.Services.Foundation.Guests;
using System;
using Tynamix.ObjectFiller;

namespace Sheenam.Api.Tests.Unit.Services.Foundation.Guests
{
    public partial class GuestServiceTests
    {
        private readonly Mock<IStorageBroker> storageBrokerMock;
        private readonly IGuestService guestService;

        public GuestServiceTests()
        {
          this.storageBrokerMock=new Mock<IStorageBroker>();  
          this.guestService=new GuestService(this.storageBrokerMock.Object);
        }

        private static Guest CreateRandomGuest() =>
            CreateGuestFiller(date: GetRandomDateTimeOffset()).Create();

        private static DateTimeOffset GetRandomDateTimeOffset() =>
            new DateTimeRange(earliestDate: new DateTime()).GetValue();

        private static Filler<Guest> CreateGuestFiller(DateTimeOffset date)
        {
            var filler=new Filler<Guest>();

            _ = filler.Setup()
                .OnType<DateTimeOffset>().Use(date);
            return filler;
        }
    }
}
