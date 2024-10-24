
using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.User;
using MedicalAppointmentApp.Domain.Entities.User;
using Microsoft.Extensions.Logging;

namespace MedicalappointmentApp.Persistance.Repositories.User
{
    public class PatientsRepository : BaseRepository<Patients>, IPatientsRepository
    {
        private readonly MedicalContext context;
        private readonly ILogger<PatientsRepository> logger;

        public PatientsRepository(MedicalContext context, ILogger<PatientsRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }
    }
}
