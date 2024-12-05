

using MedicalAppointmentApp.Infraestructure.Interfaces;
using MedicalAppointmentApp.Infraestructure.Models;
using MedicalAppointmentApp.Infraestructure.Results;

namespace MedicalAppointmentApp.Infraestructure.Services
{
    public class PushNotificationService : INotificationPush
    {
        public async Task<NotificationResult> SendPushNotification(PushModel pushModel)
        {
            NotificationResult result = new NotificationResult();
            Console.WriteLine("Enviando push notification");
            return result;
        }
    }
}
