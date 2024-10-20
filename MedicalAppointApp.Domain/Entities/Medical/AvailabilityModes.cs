using MedicalAppointApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointmentApp.Domain.Entities.Medical
{
    internal class AvailabilityModes : BaseEntity
    {
        public string SAvailabilityModeID { get; set; }  //smallint

        public string AvailabilityMode { get; set; }

        
    }
}
