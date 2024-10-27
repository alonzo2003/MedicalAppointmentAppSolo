using MedicalAppointApp.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicalAppointmentApp.Domain.Entities.Medical
{
    [Table("AvailabilityModes", Schema = "dbo")]
    public sealed class AvailabilityModes : BaseEntity
    {
        [Key]
        public short SAvailabilityModeID { get; set; }  

        public string? AvailabilityMode { get; set; }

        
    }
}
