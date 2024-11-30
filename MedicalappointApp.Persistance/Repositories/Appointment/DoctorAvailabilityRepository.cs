using MedicalAppointApp.Domain.Entities.Appointment;
using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.Appointment;
using MedicalappointmentApp.Persistance.Models.Appointment;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

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
                operationResult.Message = "La hora de inicio de la cita es requerida.";
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
            if (await base.Exists(doctorAvailability => doctorAvailability.DoctorID == entity.DoctorID
                                   && doctorAvailability.AvailableDate == entity.AvailableDate
                                   && doctorAvailability.AvailabilityID ==  entity.AvailabilityID))
            {
                operationResult.Success = false;
                operationResult.Message = "Ya existe una con estas indicaciones";
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
        public async override Task<OperationResult> Update(DoctorAvailability entity)
        {
            OperationResult operationResult = new OperationResult();

            try
            {

                if (entity == null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "La entidad es requerida.";
                    return operationResult;
                }
                if (entity.DoctorID <= 0)
                {
                    operationResult.Success = false;
                    operationResult.Message = "El Id del Doctor es requerido y debe ser mayor a cero.";
                    return operationResult;
                }

                if (entity.AvailableDate == DateOnly.MinValue)
                {
                    operationResult.Success = false;
                    operationResult.Message = "La fecha de la cita es requerida.";
                    return operationResult;
                }
                if (entity.StartTime == TimeOnly.MinValue)
                {
                    operationResult.Success = false;
                    operationResult.Message = "La hora de inicio es requerida.";
                    return operationResult;
                }
                if (entity.EndTime == TimeOnly.MinValue)
                {
                    operationResult.Success = false;
                    operationResult.Message = "La hora de fin es requerida.";
                    return operationResult;
                }
                if (entity.StartTime >= entity.EndTime)
                {
                    operationResult.Success = false;
                    operationResult.Message = "La hora de inicio debe ser menor que la hora de fin.";
                    return operationResult;
                }
                await base.Update(entity);
            }
            catch (Exception ex) {

                operationResult.Message = "Ocurrio un error actualizando la disponibilidad del doctor";
                operationResult.Success = false;
                this.logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
            


        }
        public async override Task<OperationResult> Remove(DoctorAvailability entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity == null)
            {
                operationResult.Success=false;
                operationResult.Message = "La entidad es requerida";
                return operationResult;
            }
            if (entity.AvailabilityID == 0)
            {
                operationResult.Success = false;
                operationResult.Message = "Se requiere enviar el id de la disponibilidad del medico para realizar esta operación";
                return operationResult;
            }
            try
            {
                DoctorAvailability? doctoravailabilityToRemove = await _medicalContext.DoctorAvailability.FirstOrDefaultAsync(a => a.AvailabilityID == entity.AvailabilityID);
                
                if (doctoravailabilityToRemove == null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "No se encontro la disponibilidad del doctor para eliminar";
                    return operationResult;
                }
                doctoravailabilityToRemove.AvailabilityID = 0;
                operationResult = await base.Update(doctoravailabilityToRemove);
            }
            catch (Exception ex) {
                operationResult.Message = "Ocurrio un error eliminando la disponibilidad del doctor";
                operationResult.Success= false;
                this.logger.LogError(operationResult.Message,ex.ToString());

            }
            return operationResult;

        }

        public async override Task<OperationResult> GetAll()
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                operationResult.Data = await (from doctoravailability in _medicalContext.DoctorAvailability
                                              where doctoravailability.AvailabilityID != 0
                                              select new DoctorsAvailabilityModel()
                                              {
                                                  DoctorID = doctoravailability.DoctorID,
                                                  AvailableDate = doctoravailability.AvailableDate,
                                                  StartTime = doctoravailability.StartTime,
                                                  EndTime = doctoravailability.EndTime,
                                                  AvailabilityID = doctoravailability.AvailabilityID,
                                              }).AsNoTracking().FirstOrDefaultAsync();
                                              

            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Error obteniendo los datos de la disponibilidad del doctor";
                logger.LogError(operationResult.Message,ex.ToString());

            }
            return operationResult;

        }

        public async override Task<OperationResult> GetEntityBy(int Id)
        {
            OperationResult result = new OperationResult();

            try
            {
                result.Data = await (from doctoravailability in this._medicalContext.DoctorAvailability
                                     where doctoravailability.AvailabilityID == Id
                                     select new DoctorsAvailabilityModel()
                                     {
                                         DoctorID = doctoravailability.DoctorID,
                                         AvailableDate = doctoravailability.AvailableDate,
                                         StartTime = doctoravailability.StartTime,
                                         EndTime = doctoravailability.EndTime,
                                         AvailabilityID = doctoravailability.AvailabilityID,
                                     }).AsNoTracking()
                                     .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error obteniendo los datos de la disponibilidad del doctor";
                result.Success = false;
                this.logger.LogError(result.Message,ex.ToString());
            }
            return result;

        }

        public async Task<OperationResult> GetDoctorAvailabilityById(int availabilityId)
        {

            OperationResult result = new OperationResult();

            try
            {
                DoctorAvailability? doctorAvailability = await _medicalContext.DoctorAvailability.FindAsync(availabilityId);

                if (doctorAvailability == null)
                {
                    result.Success = false;
                    result.Message = "La Disponibilidad del doctor no se encuentra registrada";
                    return result;
                }

                result.Data = availabilityId;
            }
            catch (Exception ex)
            {
                result.Message = "Ocurrio un error obteniendo las disponibilidades del doctor;";
                result.Success = false;
                this.logger.LogError(result.Message, ex.ToString());
            }
            return result;

        }
    }

}
