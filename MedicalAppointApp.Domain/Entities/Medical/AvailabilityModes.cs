using MedicalAppointApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointmentApp.Domain.Entities.Medical
{
    [Table("AvailabilityModes", Schema = "dbo")]
    public sealed class AvailabilityModes : BaseEntity
    {
        [Key]
        public string? SAvailabilityModeID { get; set; }  

        public string? AvailabilityMode { get; set; }

        
    }
}
