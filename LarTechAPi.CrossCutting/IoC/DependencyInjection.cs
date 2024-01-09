using LarTechAPi.Application.Interfaces;
using LarTechAPi.Application.Mappings;
using LarTechAPi.Application.Services;
using LarTechAPi.Domain.Interfaces;
using LarTechAPi.Infrastructure.Context;
using LarTechAPi.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LarTechAPi.CrossCutting.IoC
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPhoneRepository, PhoneRepository>();

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPhoneService, PhoneService>();

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));

            return services;
        }
    }
}
