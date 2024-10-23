using MedicalAppointApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointmentApp.Domain.Entities.User
{
    [Table("Users", Schema = "dbo")]
    public sealed class Users : BaseEntity
    {
        [Key]
        public int UserID { get; set; } //PK

        public string? FirstName { get; set; } //100

        public string? LastName { get; set; } //100

        public string? Email { get; set; } //255

        public string? Password { get; set; } //255

        public int RoleID { get; set; } //FK

        
    } 
}
