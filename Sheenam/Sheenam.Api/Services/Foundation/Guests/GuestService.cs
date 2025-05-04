//================================
//Copyright (C) Coalitionof Good-Hearted Engineers
//Free To Use Comfort and Peace
//================================

using Sheenam.Api.Brokers.Storages;
using Sheenam.Api.Models.Foundations;
using System.Threading.Tasks;

namespace Sheenam.Api.Services.Foundation.Guests
{
    public class GuestService : IGuestService
    {
        private readonly IStorageBroker storageBroker;

        public GuestService(IStorageBroker storageBroker)
        {
            this.storageBroker = storageBroker; 
        }
        public ValueTask<Guest> AddGuestAsync(Guest guest)=>
        this.storageBroker.InsertGuestAsync(guest);       
    }
}
