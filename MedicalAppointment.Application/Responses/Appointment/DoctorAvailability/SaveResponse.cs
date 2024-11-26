
using MedicalAppointment.Application.Core;

namespace MedicalAppointment.Application.Responses.Appointment.DoctorAvailability
{
    public sealed class SaveResponse : BaseResponse
    {
        public int AvailabilityID { get; set; }

    }
}
