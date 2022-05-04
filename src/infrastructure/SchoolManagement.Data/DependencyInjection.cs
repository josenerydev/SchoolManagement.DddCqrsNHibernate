using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using SchoolManagement.Data.Repositories;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Repositories;

namespace SchoolManagement.Data
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureData(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            var sessionFactory = new SessionFactory(connectionString);
            services.AddSingleton(sessionFactory);
            services.AddScoped<UnitOfWork>();
            services.AddTransient<IStudentRepository, StudentRepository>();
            return services;
        }
    }
}
