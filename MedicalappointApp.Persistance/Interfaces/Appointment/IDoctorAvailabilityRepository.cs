using MedicalAppointApp.Domain.Entities.Appointment;
using MedicalAppointmentApp.Domain.Repositories;
using MedicalAppointmentApp.Domain.Result;


namespace MedicalappointmentApp.Persistance.Interfaces.Appointment
{
    public interface IDoctorAvailabilityRepository : IBaseRepository<DoctorAvailability>
    {
        Task<OperationResult> GetDoctorAvailabilityById(int availabilityId);
    }
}
