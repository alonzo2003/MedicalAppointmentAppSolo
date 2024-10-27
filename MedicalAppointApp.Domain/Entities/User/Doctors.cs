using MedicalAppointApp.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicalAppointmentApp.Domain.Entities.User
{
    [Table("Doctors", Schema = "dbo")]
    public sealed class Doctors : BaseEntity
    {
        [Key]
        public int DoctorId { get; set; } 

        public short SpecialtyID { get; set; } 

        public string? LicenseNumber { get; set; }

        public string? PhoneNumber { get; set; }

        public string? YearsOfExperience { get; set; }

        public string? Education {  get; set; } 
            
        public string? Bio {  get; set; } 

        public decimal? ConsultationFee { get; set; } 

        public string? ClinicAddress { get; set; }

        public short AvailabilityModeID { get; set; } 

        public DateOnly LicenseExpirationDate { get; set; }

      
    }
}
