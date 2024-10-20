using MedicalAppointApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointmentApp.Domain.Entities.Medical
{
    internal class Specialties : BaseEntity
    {
        public string SpecialtyID { get; set; } //smallint

        public string SpecialtyName { get; set; }

       


    }
}
