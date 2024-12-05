

using MedicalAppointmentApp.Infraestructure.Models;
using MedicalAppointmentApp.Infraestructure.Results;

namespace MedicalAppointmentApp.Infraestructure.Interfaces
{
    public interface INotificationSms
    {
        Task<NotificationResult> SendSmsAsync(SmsModel smsModel);
    }
}
