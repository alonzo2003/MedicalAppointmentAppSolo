using MedicalAppointApp.Domain.Entities.Appointment;
using MedicalAppointmentApp.Domain.Repositories;
using MedicalAppointmentApp.Domain.Result;

namespace MedicalappointmentApp.Persistance.Interfaces.appointment
{
    public interface IAppointmentsRepository : IBaseRepository<Appointments>
    {

    }
}
