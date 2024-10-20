

using MedicalAppointApp.Domain.Base;

namespace MedicalAppointmentApp.Domain.Entities.Insurance
{
     public class NetworkType : BaseEntity
    {
        public int NetworkTypeId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

     


    }
}
