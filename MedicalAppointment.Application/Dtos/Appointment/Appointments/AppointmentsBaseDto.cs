

namespace MedicalAppointment.Application.Dtos.Appointment.Appointments
{
    public class AppointmentsBaseDto
    {

        public int PatientID { get; set; }

        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }



    }
}
