using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicalAppointmentApp.Domain.Entities.System
{
    [Table("Notifications", Schema = "dbo")]
    public sealed class Notifications
    {
        [Key]
        public int NotificationID { get; set; } 

        public int UserID { get; set; }

        public string? Message { get; set; } //text

        public DateTime? SentAt { get; set; }
    }
}
