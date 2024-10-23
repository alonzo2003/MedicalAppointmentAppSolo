using MedicalAppointApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointmentApp.Domain.Entities.System
{
    [Table("Roles", Schema = "dbo")]
    public sealed class Roles : BaseEntity
    {
        [Key]
        public int RoleId { get; set; }

        public string? RoleName { get; set; }

       
    }
}
