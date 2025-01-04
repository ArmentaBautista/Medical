using Dapper;
using Medical.Application.Abstractions.Communication;
using Medical.Application.Abstractions.Data;
using Medical.Application.Abstractions.Time;
using Medical.Domain.Abstractions;
using Medical.Domain.Appointments;
using Medical.Domain.Doctors;
using Medical.Domain.Patients;
using Medical.Domain.Users;
using Medical.Infrastructure.Appointments;
using Medical.Infrastructure.Doctors;
using Medical.Infrastructure.Implementations.Communication;
using Medical.Infrastructure.Implementations.Data;
using Medical.Infrastructure.Patients;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Medical.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            var connectionString = configuration.GetConnectionString("conexion") ??
                    throw new ArgumentNullException(nameof(configuration));

            services.AddTransient<ITimeProvider, Implementations.Time.TimeProvider>();
            services.AddTransient<IEmailService, EmailService>();

            //Configuring the context
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.AddScoped<IDoctorRepository, DoctorRepository>();
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();

            services.AddScoped<IUnitOfWork>(x => x.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(_ =>
                new SqlConnectionFactory(connectionString));
            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

            return services;
        }
    }
}
