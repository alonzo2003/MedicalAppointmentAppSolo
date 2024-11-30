
namespace MedicalAppointment.Application.Dtos.Appointment.DoctorAvailability
{
    public class DoctorAvailabilityBaseDto
    {
        public int DoctorID { get; set; }

        public DateOnly AvailableDate { get; set; }

        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
