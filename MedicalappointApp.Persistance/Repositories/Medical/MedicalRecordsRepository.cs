using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.Medical;
using MedicalAppointmentApp.Domain.Entities.Medical;
using Microsoft.Extensions.Logging;


namespace MedicalappointmentApp.Persistance.Repositories.Medical
{
    public sealed class MedicalRecordsRepository : BaseRepository<MedicalRecords>, IMedicalRecordsRepository
    {
        private readonly MedicalContext context;
        private readonly ILogger<MedicalRecordsRepository> logger;

        public MedicalRecordsRepository(MedicalContext context, ILogger<MedicalRecordsRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }

    }

    
}
