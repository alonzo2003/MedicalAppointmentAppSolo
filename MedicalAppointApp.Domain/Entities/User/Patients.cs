using MedicalAppointApp.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MedicalAppointmentApp.Domain.Entities.User
{
    [Table("Patients", Schema = "dbo")]
    public sealed class Patients : BaseEntity
    {
        [Key]
        public int PatientID { get; set; } 

        public DateOnly DateOfBirth { get; set; } 

        public string? Gender { get; set; } 

        public string? PhoneNumber { get; set; } 

        public string? Address { get; set; } 

        public string? EmergencyContactName { get; set; } 

        public string? EmergencyContactPhone {  get; set; } 

        public string? BloodType { get; set; } 

        public string? Allergies { get; set; } 

        public int InsuranceProviderID {  get; set; } 

       
    }
}
