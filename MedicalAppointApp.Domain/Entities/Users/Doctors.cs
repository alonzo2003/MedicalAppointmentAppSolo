using MedicalAppointApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointmentApp.Domain.Entities.Users
{
    internal class Doctors : BaseEntity
    {
        public int DoctorId { get; set; } //PK FK 

        public int SpecialtyID { get; set; } // FK Smallint

        public string LicenseNumber { get; set; }

        public string PhoneNumber { get; set; }

        public string YearsOfExperience { get; set; }

        public string Education {  get; set; } //nvarchar(max)
            
        public string ? Bio {  get; set; } //nvarchar (max)

        public decimal? ConsultationFee { get; set; } //10,2

        public string? ClinicAddress { get; set; }

        public string? AvailabilityModeID { get; set; } //smallint FK

        public DateOnly LicenseExpirationDate { get; set; }

      
    }
}
