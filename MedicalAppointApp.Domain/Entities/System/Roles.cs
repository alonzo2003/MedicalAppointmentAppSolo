using MedicalAppointApp.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
