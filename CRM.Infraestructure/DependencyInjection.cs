using CRM.Application.Interfaces;
using CRM.Application.Services;
using CRM.Domain.Interfaces;
using CRM.Infraestructure.Data;
using CRM.Infraestructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CRM.Infraestructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();

            services.AddScoped<IEjecutivoRepository, EjecutivoRepository>();
            services.AddScoped<IEjecutivoService, EjecutivoService>();

            services.AddScoped<IVentaRepository, VentaRepository>();
            services.AddScoped<IVentaService, VentaService>();

            services.AddScoped<IVisitaRepository, VisitaRepository>();
            services.AddScoped<IVisitaService, VisitaService>();
            return services;
        }
    }
}
