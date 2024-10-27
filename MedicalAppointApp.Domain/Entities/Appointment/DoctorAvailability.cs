using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointApp.Domain.Entities.Appointment
{
    [Table("DoctorAvailability", Schema = "dbo")]
    public sealed class DoctorAvailability
    {
        [Key]
        public int AvailabilityID { get; set; }

        public int DoctorID { get; set; }

        public DateOnly AvailableDate { get; set; }

        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
    }
}
