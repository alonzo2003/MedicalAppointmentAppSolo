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
    [Table("Specialties", Schema = "dbo")]
    public sealed class Specialties : BaseEntity
    {
        [Key]
        public short SpecialtyID { get; set; } 

        public string? SpecialtyName { get; set; }

       


    }
}
