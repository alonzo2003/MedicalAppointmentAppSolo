using MedicalAppointApp.Domain.Entities.Appointment;
using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.appointment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalappointmentApp.Persistance.Repositories.Appointment
{
    public class AppointmentsRepository : BaseRepository<Appointments>, IAppointmentsRepository
    {
        public AppointmentsRepository(MedicalContext medicalContext) : base(medicalContext)
        {
        }
    }
}
