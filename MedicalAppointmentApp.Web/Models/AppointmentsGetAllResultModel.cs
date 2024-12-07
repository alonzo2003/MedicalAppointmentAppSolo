using MedicalappointmentApp.Persistance.Models.Appointment;

namespace MedicalAppointmentApp.Web.Models
{
    public class AppointmentsGetAllResultModel : BaseApiResponseModel
    {
        
        public List<AppointmentsModel> data { get; set; }
       
    }
}

