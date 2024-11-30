
namespace MedicalAppointment.Application.Dtos.Appointment.DoctorAvailability
{
    public class DoctorAvailabilityUpdateDto : DoctorAvailabilityBaseDto
    {
        public int AvailabilityID { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

    }
}
