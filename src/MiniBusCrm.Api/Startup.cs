using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MiniBusCrm.Domain.Contracts.Services;
using MiniBusCrm.Domain.Implementations.Profiles;
using MiniBusCrm.Domain.Implementations.Services;
using Newtonsoft.Json;

namespace MiniBusCrm.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);
            services.AddDatabase(Configuration);
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddSwagger();
            services.AddCors();
            services.AddTransient<IPlaneService, PlaneService>()
                .AddTransient<IRouteService, RouteService>()
                .AddTransient<ITicketService, TicketService>()
                .AddTransient<IBusDriverService, BusDriverService>()
                .AddTransient<IBusService, BusService>()
                .AddTransient<IPassengerService, PassengerService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin();
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("/swagger/v1/swagger.json", "MiniBus Crm v1");
                x.RoutePrefix = "swagger";
            });

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}