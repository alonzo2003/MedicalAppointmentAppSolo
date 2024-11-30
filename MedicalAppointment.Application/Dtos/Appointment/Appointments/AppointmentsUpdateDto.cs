

namespace MedicalAppointment.Application.Dtos.Appointment.Appointments
{
    public sealed class AppointmentsUpdateDto: AppointmentsBaseDto
    {
        public int AppointmentID { get; set; }

        public int StatusID { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}
