using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointmentApp.Domain.Entities.System
{
    internal class Notifications
    {
        public int NotificationID { get; set; } 

        public int UserID { get; set; }

        public string Message { get; set; } //text

        public DateTime? SentAt { get; set; }
    }
}
