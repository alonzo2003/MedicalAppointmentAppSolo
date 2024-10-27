﻿using MedicalAppointApp.Domain.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalAppointmentApp.Domain.Entities.Insurance
{
    [Table("NetworkType", Schema = "dbo")]
    public class NetworkType : BaseEntity

    {
        [Key]
        public int NetworkTypeId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

     


    }
}
