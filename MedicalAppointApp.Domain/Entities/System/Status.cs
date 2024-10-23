﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointmentApp.Domain.Entities.System
{
    [Table("Status", Schema = "dbo")]
    public sealed class Status
    {
        [Key]
        public int StatusID { get; set; }
        public string? StatusName { get; set; }
    }
}
