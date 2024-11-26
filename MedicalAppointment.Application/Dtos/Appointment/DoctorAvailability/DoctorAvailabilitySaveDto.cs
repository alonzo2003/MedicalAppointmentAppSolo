
namespace MedicalAppointment.Application.Dtos.Appointment.DoctorAvailability
{
     public class DoctorAvailabilitySaveDto
    {
        

        public int DoctorID { get; set; }

        public DateOnly AvailableDate { get; set; }

        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public DateTime CreatedAt { get; set; }


    }
}
