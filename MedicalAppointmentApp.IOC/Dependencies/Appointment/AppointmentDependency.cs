using Microsoft.Extensions.DependencyInjection;
using MedicalappointmentApp.Persistance.Interfaces.appointment;
using MedicalappointmentApp.Persistance.Interfaces.Appointment;
using MedicalappointmentApp.Persistance.Repositories.Appointment;
using MedicalAppointment.Application.Contracts;
using MedicalAppointment.Application.Services.Appointment;


namespace MedicalAppointmentApp.IOC.Dependencies.Appointment
{
    public static class AppointmentDependency
    {
        public static void AddAppointmentDependency(this IServiceCollection service)
        {
            service.AddScoped<IAppointmentsRepository, AppointmentsRepository>();

            service.AddScoped<IDoctorAvailabilityRepository, DoctorAvailabilityRepository>();

            service.AddTransient<IAppointmentsService, AppointmentsService>();
        }
    }
}
