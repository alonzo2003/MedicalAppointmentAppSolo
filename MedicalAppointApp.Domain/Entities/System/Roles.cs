using MedicalAppointApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointmentApp.Domain.Entities.System
{
    internal class Roles : BaseEntity
    {
        public int RoleId { get; set; }

        public string RoleName { get; set; }

       
    }
}
