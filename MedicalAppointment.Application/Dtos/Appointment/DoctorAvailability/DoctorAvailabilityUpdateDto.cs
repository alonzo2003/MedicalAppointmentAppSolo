
namespace MedicalAppointment.Application.Dtos.Appointment.DoctorAvailability
{
    public class DoctorAvailabilityUpdateDto
    {
        public int AvailabilityID { get; set; }

        public int DoctorID { get; set; }

        public DateOnly AvailableDate { get; set; }

        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

    }
}
