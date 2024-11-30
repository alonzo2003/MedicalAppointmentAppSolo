

using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Dtos.Appointment.Appointments;
using MedicalAppointment.Application.Responses.Appointment.Appointments;

namespace MedicalAppointment.Application.Contracts
{
    public interface IAppointmentsService : IBaseService<AppointmentsResponse, AppointmentsSaveDto, AppointmentsUpdateDto>
    {
    }
}
