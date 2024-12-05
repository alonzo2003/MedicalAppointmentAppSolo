

using MedicalAppointmentApp.Infraestructure.Interfaces;
using MedicalAppointmentApp.Infraestructure.Models;
using MedicalAppointmentApp.Infraestructure.Results;
using Newtonsoft.Json;
using System.Text;

namespace MedicalAppointmentApp.Infraestructure.Services
{
    public class SmsService : INotificationSms
    {
        public async Task<NotificationResult> SendSmsAsync(SmsModel smsModel)
        {
            NotificationResult result = new NotificationResult();

            try
            {
                var httpClient = new HttpClient();

                var contect = new StringContent(JsonConvert.SerializeObject(smsModel), Encoding.UTF8, "application/json");

                await httpClient.PostAsync("miurl", contect);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
