using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.Medical;
using MedicalAppointmentApp.Domain.Entities.Medical;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.Extensions.Logging;


namespace MedicalappointmentApp.Persistance.Repositories.Medical
{
    public sealed class MedicalRecordsRepository (MedicalContext medicalContext,
        ILogger<MedicalRecordsRepository> logger) : BaseRepository<MedicalRecords>(medicalContext), IMedicalRecordsRepository
    {
        private readonly MedicalContext medicalContext = medicalContext;
        private readonly ILogger<MedicalRecordsRepository> logger = logger;


        public override Task<OperationResult> Save(MedicalRecords entity)
        {
            return base.Save(entity);
        }
    }

    
}
