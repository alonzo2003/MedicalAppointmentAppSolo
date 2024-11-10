

namespace MedicalappointmentApp.Persistance.Models.Appointment
{
    public class DoctorsAvailabilityModel
    {
        public int AvailabilityID { get; set; }

        public int DoctorID { get; set; }

        public DateOnly AvailableDate { get; set; }

        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}
