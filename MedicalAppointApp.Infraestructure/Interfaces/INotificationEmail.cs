
using MedicalAppointmentApp.Infraestructure.Models;
using MedicalAppointmentApp.Infraestructure.Results;

namespace MedicalAppointmentApp.Infraestructure.Interfaces
{
    public interface INotificationEmail
    {
        Task<NotificationResult> SendEmailAsync(EmailModel emailModel);
    }
}
