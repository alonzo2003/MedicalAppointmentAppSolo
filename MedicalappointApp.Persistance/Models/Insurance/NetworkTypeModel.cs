
namespace MedicalappointmentApp.Persistance.Models.Insurance
{
    public class NetworkTypeModel
    {
        public int NetworkTypeId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public bool IsActive { get; set; }

    }
}
