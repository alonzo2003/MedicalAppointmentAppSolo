using MedicalappointmentApp.Persistance.Models.Appointment;

namespace MedicalAppointmentApp.Web.Models.Appointments
{
    public class AppointmentsGetByIdModel : BaseApiResponseModel
    {
        public AppointmentsModel Data { get; set; }
    }
}
