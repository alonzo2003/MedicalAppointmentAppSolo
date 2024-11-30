using MedicalAppointApp.Domain.Entities.Appointment;
using MedicalappointmentApp.Persistance.Interfaces.appointment;
using MedicalAppointmentApp.Domain.Repositories;
using MedicalAppointmentApp.Domain.Result;

namespace MedicalappointmentApp.Persistance.Interfaces.appointment
{
    public interface IAppointmentsRepository : IBaseRepository<Appointments>
    {
        Task<OperationResult> GetAppointmentsById(int appointmentId);
    }
}
