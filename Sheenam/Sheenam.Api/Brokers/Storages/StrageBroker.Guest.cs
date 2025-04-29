//================================
//Copyright (C) Coalitionof Good-Hearted Engineers
//Free To Use Comfort and Peace
//================================


using Microsoft.EntityFrameworkCore;
using Sheenam.Api.Models.Foundations;

namespace Sheenam.Api.Brokers.Storages
{
    public partial class StrageBroker
    {
        public DbSet<Guest> Guests { get; set; }
    }
}
