using MedicalAppointApp.Domain.Entities.Appointment;
using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.Appointment;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.Extensions.Logging;

namespace MedicalappointmentApp.Persistance.Repositories.Appointment
{
    public sealed class DoctorAvailabilityRepository : BaseRepository<DoctorAvailability>, IDoctorAvailabilityRepository
    {
        private readonly MedicalContext context;
        private readonly ILogger<DoctorAvailabilityRepository> logger;

        public DoctorAvailabilityRepository(MedicalContext context, ILogger<DoctorAvailabilityRepository> logger) :base(context)
        {
            this.context = context;
            this.logger = logger;
        }

        public async override Task<OperationResult> Save(DoctorAvailability entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity == null)
            {
                operationResult.Success = false;
                operationResult.Message = "La entidad es requerida.";
                return operationResult;
            }

            return await base.Save(entity);
        }

    }
}
