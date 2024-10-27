using MedicalAppointApp.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicalAppointmentApp.Domain.Entities.User
{
    [Table("Users", Schema = "dbo")]
    public sealed class Users : BaseEntity
    {
        [Key]
        public int UserID { get; set; } 

        public string? FirstName { get; set; } 

        public string? LastName { get; set; } 

        public string? Email { get; set; } 

        public string? Password { get; set; } 

        public int RoleID { get; set; } 

        
    } 
}
