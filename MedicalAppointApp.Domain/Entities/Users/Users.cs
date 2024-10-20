using MedicalAppointApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointmentApp.Domain.Entities.Users
{
    internal class Users : BaseEntity
    {
        public int UserID { get; set; } //PK

        public string FirstName { get; set; } //100

        public string LastName { get; set; } //100

        public string Email { get; set; } //255

        public string Password { get; set; } //255

        public int RoleID { get; set; } //FK

        
    } 
}
