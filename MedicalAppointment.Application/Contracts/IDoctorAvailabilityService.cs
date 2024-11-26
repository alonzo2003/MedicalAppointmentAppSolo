

using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Dtos.Appointment.DoctorAvailability;
using MedicalAppointment.Application.Responses.Appointment.DoctorAvailability;

namespace MedicalAppointment.Application.Contracts
{
    public interface IDoctorAvailabilityService : IBaseService<DoctorAvailabilityResponse, DoctorAvailabilitySaveDto, DoctorAvailabilityUpdateDto>
    {

    }
    
}
