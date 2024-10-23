using MedicalAppointApp.Domain.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointmentApp.Domain.Entities.Medical
{
    [Table("MedicalRecords", Schema = "dbo")]
    public sealed class MedicalRecords : BaseEntity
    {
        [Key]
        public int RecordID { get; set; }

        public int PatientID { get; set; }

        public int DoctorID { get; set; }

        public int Diagnosis { get; set; }//text
        
        public int Treatment { get; set; } //text

        public DateTime DateOfVisit { get; set; }

     
        

    }
}
