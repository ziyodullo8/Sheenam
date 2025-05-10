//================================
//Copyright (C) Coalitionof Good-Hearted Engineers
//Free To Use Comfort and Peace
//================================




using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Sheenam.Api.Brokers.Storages;


namespace Sheenam.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)=>
            Configuration = configuration;
        

        public IConfiguration Configuration { get; }

       
        public void ConfigureServices(IServiceCollection services)
        {
            var apiInfo = new OpenApiInfo
            {
                Title = "Sheenam.Api",
                Version = "1"
            };

            _ = services.AddDbContext<StorageBroker>();
            _ = services.AddControllers();
            _ = services.AddControllers();

            _ = services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    name: "v1",
                    info: apiInfo
                    );
            });
            
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
                _ = app.UseSwagger();
                _ = app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sheenam.Api v1"));
            }

            _ = app.UseHttpsRedirection();

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.UseEndpoints(endpoints =>

                endpoints.MapControllers());
          
        }
    }
}
