

namespace MedicalAppointApp.Domain.Entities.appointments
{
    public sealed class DoctorAvailability
    {
        public int AvailabilityID { get; set; }

        public int DoctorID { get; set; }

        public DateOnly AvailableDate { get; set; }

        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
