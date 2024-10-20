using MedicalAppointApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointmentApp.Domain.Entities.Users
{
    internal class Patients : BaseEntity
    {
        public int PatientID { get; set; } // PK, FK,

        public DateOnly DateOfBirth { get; set; } 

        public string Gender { get; set; } // char(1)

        public string PhoneNumber { get; set; } //15

        public string Address { get; set; } //255

        public string EmergencyContactName { get; set; } //100

        public string EmergencyContactPhone {  get; set; } //15

        public string BloodType { get; set; } //char(2)

        public string Allergies { get; set; } //nvarchar(max)

        public int InsuranceProviderID {  get; set; } //FK

       
    }
}
