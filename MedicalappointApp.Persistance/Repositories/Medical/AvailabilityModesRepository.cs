using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.Medical;
using MedicalAppointmentApp.Domain.Entities.Medical;
using MedicalAppointmentApp.Domain.Repositories;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.Extensions.Logging;


namespace MedicalappointmentApp.Persistance.Repositories.Medical
{
    public sealed class AvailabilityModesRepository (MedicalContext medicalContext,
       ILogger<AvailabilityModesRepository> logger ) : BaseRepository<AvailabilityModes>(medicalContext), IAvailabilityModesRepository

        
    {
        private readonly MedicalContext _medicalContext = medicalContext;
        private readonly ILogger<AvailabilityModesRepository> logger = logger;

        public override Task<OperationResult> Save(AvailabilityModes entity)
        {
            return base.Save(entity);
        }


    }
}
