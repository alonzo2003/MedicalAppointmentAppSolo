using MedicalAppointApp.Domain.Entities.Appointment;
using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.Appointment;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.Extensions.Logging;

namespace MedicalappointmentApp.Persistance.Repositories.Appointment
{
    public sealed class DoctorAvailabilityRepository(MedicalContext medicalContext,
                                      ILogger<DoctorAvailabilityRepository> logger) : BaseRepository<DoctorAvailability>(medicalContext), IDoctorAvailabilityRepository
    {
        private readonly MedicalContext _medicalContext = medicalContext;
        private readonly ILogger<DoctorAvailabilityRepository> logger = logger;

      
        public async override Task<OperationResult> Save(DoctorAvailability entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity == null)
            {
                operationResult.Success = false;
                operationResult.Message = "La entidad es requerida.";
                return operationResult;
            }
            if (entity.DoctorID <= 0)
            {

                operationResult.Success = false;
                operationResult.Message = "El Id del Doctor es requerido y debe ser mayor a cero";
                return operationResult;
            }

            if (entity.AvailableDate == DateOnly.MinValue )
            {
                operationResult.Success = false;
                operationResult.Message = "La fecha de la cita es requerida.";
                return operationResult;
            }
            if (entity.StartTime == TimeOnly.MinValue)
            {
                operationResult.Success = false;
                operationResult.Message = "La fecha de la cita es requerida.";
                return operationResult;
            }
            if (entity.EndTime == TimeOnly.MinValue)
            {
                operationResult.Success = false;
                operationResult.Message = "La hora de fin de la cita es requerida.";
                return operationResult;
            }
            if (entity.StartTime >= entity.EndTime)
            {

                operationResult.Success = false;
                operationResult.Message = "La hora de inicio debe ser menor que la hora de fin.";
                return operationResult;
            }

            try
            {
                await base.Save(entity);
            }
            catch (Exception ex)
            {
                operationResult.Message = "Ocurrió un error guardando la disponibilidad del Doc.";
                operationResult.Success = false;
                this.logger.LogError(operationResult.Message, ex.ToString());
            }

            return operationResult;
        }
        public override Task<OperationResult> Update(DoctorAvailability entity)
        {
            return base.Update(entity);
        }
        public override Task<OperationResult> Remove(DoctorAvailability entity)
        {
            return base.Remove(entity);

        }
        //public  async override Task<OperationResult> GetAll()
        //{
        //    OperationResult result = new OperationResult();
        //    try 
        //    {
        //        result.Data = await (from doctoravailability in _medicalContext.DoctorAvailability
        //                             where doctoravailability.)
        //    }
        //}
        public override Task<OperationResult> GetEntityBy(int Id)
        {
            return base.GetEntityBy(Id);
        }
    }

}
