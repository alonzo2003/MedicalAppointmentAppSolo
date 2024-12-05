

using MedicalAppointmentApp.Infraestructure.Models;
using MedicalAppointmentApp.Infraestructure.Results;

namespace MedicalAppointmentApp.Infraestructure.Interfaces
{
    public interface INotificationPush
    {
        Task<NotificationResult> SendPushNotification(PushModel pushModel);
    }
}
