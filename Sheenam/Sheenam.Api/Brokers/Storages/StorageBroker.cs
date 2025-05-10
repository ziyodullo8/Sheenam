//================================
//Copyright (C) Coalitionof Good-Hearted Engineers
//Free To Use Comfort and Peace
//================================

using EFxceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sheenam.Api.Models.Foundations;
using System.Threading.Tasks;

namespace  Sheenam.Api.Brokers.Storages
{
    public partial class StorageBroker: EFxceptionsContext, IStorageBroker
    {
        private IConfiguration configuration;

        public StorageBroker(IConfiguration configuration) 
        {
            this.configuration = configuration;
            this.Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString =
                this.configuration.GetConnectionString(name: "DefaultConnection");

            _ = optionsBuilder.UseSqlServer(connectionString);
        }


        public override void Dispose()
        {
            base.Dispose();
        }     

    }

}