using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using MiniBusCrm.DataAccess.Contracts;
using MiniBusCrm.DataAccess.Implementations;


namespace MiniBusCrm.Api
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(builder =>
            {
                builder.EnableSensitiveDataLogging(true);

                builder.UseNpgsql(configuration.GetConnectionString("DefaultConnection"), assembly =>
                    assembly.MigrationsAssembly("MiniBusCrm.DataAccess.Migrations"));
            });
            services
                .AddScoped<IDbRepository, EfRepository>(provider =>
                    new EfRepository(provider.GetRequiredService<DataContext>()));
            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MiniBusCrm", Version = "v1" });
            });
            return services;
        }
    }
}

