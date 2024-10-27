

namespace MedicalappointmentApp.Persistance.Models.User
{
    public class DoctorsModel
    {
        public int DoctorId { get; set; }

        public short SpecialtyID { get; set; }

        public string? LicenseNumber { get; set; }

        public string? PhoneNumber { get; set; }

        public string? YearsOfExperience { get; set; }

        public string? Education { get; set; }

        public string? Bio { get; set; }

        public decimal? ConsultationFee { get; set; }

        public string? ClinicAddress { get; set; }

        public short AvailabilityModeID { get; set; }

        public DateOnly LicenseExpirationDate { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }
    }
}
