using Dapper;
using HRHub.Application.Abstractions.Clock;
using HRHub.Application.Abstractions.Data;
using HRHub.Application.Abstractions.Email;
using HRHub.Domain.Abstractions;
using HRHub.Domain.Request;
using HRHub.Domain.Users;
using HRHub.Infrastructure.Clock;
using HRHub.Infrastructure.Data;
using HRHub.Infrastructure.Email;
using HRHub.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRHub.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();
            services.AddTransient<IEmailService, EmailService>();

            var connectionString = configuration.GetConnectionString("Database") ??
                throw new ArgumentNullException(nameof(configuration));

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString).UseSnakeCaseNamingConvention();
            });

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IRequestRepository, RequestRepository>();

            services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(_ =>
                new SqlConnectionFactory(connectionString)
            );

            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());


            return services;
        }

    }
}
