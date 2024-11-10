using MedicalAppointApp.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointApp.Domain.Entities.Appointment
{
    [Table ("Appointments", Schema = "appointments")]
    public sealed class Appointments : BaseEntity
    {
        [Key]
        public int AppointmentsID { get; set; }
        public int PatientID { get; set; }

        public int DoctorID { get; set; }
        public DateTime AppointmentDate { get; set; }

        public int  StatusID { get; set; }


        //dbo.Appointments

    }
}
