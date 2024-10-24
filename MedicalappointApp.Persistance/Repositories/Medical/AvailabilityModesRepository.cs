using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.Medical;
using MedicalAppointmentApp.Domain.Entities.Medical;
using MedicalAppointmentApp.Domain.Repositories;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.Extensions.Logging;


namespace MedicalappointmentApp.Persistance.Repositories.Medical
{
    public sealed class AvailabilityModesRepository : BaseRepository<AvailabilityModes>, IAvailabilityModesRepository

        
    {
        private readonly MedicalContext context;
        private readonly ILogger<AvailabilityModesRepository> logger;

        public AvailabilityModesRepository(MedicalContext context, ILogger<AvailabilityModesRepository> logger) : base(context)
        {
            this.context = context;
            this.logger = logger;
        }
        public override Task<OperationResult> Save(AvailabilityModes entity)
        {
            return base.Save(entity);
        }


    }
}
