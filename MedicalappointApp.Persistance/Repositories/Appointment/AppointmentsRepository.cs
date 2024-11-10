using MedicalAppointApp.Domain.Entities.Appointment;
using MedicalappointmentApp.Persistance.Base;
using MedicalappointmentApp.Persistance.Context;
using MedicalappointmentApp.Persistance.Interfaces.appointment;
using MedicalappointmentApp.Persistance.Models.Appointment;
using MedicalAppointmentApp.Domain.Result;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;



namespace MedicalappointmentApp.Persistance.Repositories.Appointment
{
    public class AppointmentsRepository(MedicalContext medicalContext,
                              ILogger<AppointmentsRepository> logger) : BaseRepository<Appointments>(medicalContext), IAppointmentsRepository
    {
        private readonly MedicalContext _medicalContext = medicalContext;
        private readonly ILogger<AppointmentsRepository> logger = logger;


        public async override Task<OperationResult> Save(Appointments entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity == null)
            {
                operationResult.Success = false;
                operationResult.Message = "La entidad es requerida.";
                return operationResult;
            }
            //if (entity.PatientID == 0)
            //{
            //    operationResult.Success = false;
            //    operationResult.Message = "El  Id del paciente es requerido.";
            //    return operationResult;
            //}

            //if (entity.DoctorID == 0)
            //{
            //    operationResult.Success = false;
            //    operationResult.Message = "El Id del doctor es requerido.";
            //    return operationResult;
            //}

            //if (entity.StatusID == 0)
            //{
            //    operationResult.Success = false;
            //    operationResult.Message = "El estado es requerido.";
            //    return operationResult;
            //}
            if (entity.AppointmentDate == DateTime.MinValue)
            {
                operationResult.Success = false;
                operationResult.Message = "La fecha de la cita es requerida.";
                return operationResult;
            }
            if (await base.Exists(appointments => appointments.PatientID == entity.PatientID
                                  && appointments.DoctorID == entity.DoctorID
                                  && appointments.AppointmentDate == entity.AppointmentDate))

            {
                operationResult.Success = false;
                operationResult.Message = "Ya existe una cita con este paciente, doctor y fecha.";
                return operationResult;
            }

            try
            {
                operationResult = await base.Save(entity);
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Error guardando la cita.";
                logger.LogError(operationResult.Message, ex.ToString());

            }
            return operationResult;
        }
        public async override Task<OperationResult> Update(Appointments entity)
        {
            OperationResult operationResult = new OperationResult();

            if (entity == null)
            {
                operationResult.Success = false;
                operationResult.Message = "La entidad es requerida.";
                return operationResult;
            }
            if (entity.PatientID == 0)
            {
                operationResult.Success = false;
                operationResult.Message = "El paciente es requerido.";
                return operationResult;
            }

            if (entity.DoctorID == 0)
            {
                operationResult.Success = false;
                operationResult.Message = "El doctor es requerido.";
                return operationResult;
            }

            if (entity.StatusID == 0)
            {
                operationResult.Success = false;
                operationResult.Message = "El estado es requerido.";
                return operationResult;
            }
            if (entity.AppointmentDate == DateTime.MinValue)
            {
                operationResult.Success = false;
                operationResult.Message = "La fecha de la cita es requerida.";
                return operationResult;
            }

            try
            {
                Appointments? appointmentsToUpdate = await _medicalContext.Appointments.Where(a => a.AppointmentID == entity.AppointmentID).FirstOrDefaultAsync();

                if (appointmentsToUpdate == null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "La cita no existe.";
                    return operationResult;
                }

                appointmentsToUpdate.AppointmentDate = entity.AppointmentDate;
                appointmentsToUpdate.UpdatedAt = DateTime.Now;
                appointmentsToUpdate.PatientID = entity.PatientID;
                appointmentsToUpdate.DoctorID = entity.DoctorID;
                appointmentsToUpdate.StatusID = entity.StatusID;

                operationResult = await base.Update(appointmentsToUpdate);
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Error actualizando la cita.";
                logger.LogError(operationResult.Message, ex.ToString());

            }
            return operationResult;
        }
        public async override Task<OperationResult> Remove(Appointments entity)
        {
            OperationResult operationResult = await base.Remove(entity);

            if (entity == null)
            {
                operationResult.Success = false;
                operationResult.Message = "La entidad es requerida";
                return operationResult;
            }
            if (entity.StatusID == 0)
            {
                operationResult.Success = false;
                operationResult.Message = "El estado es requerido";
                return operationResult;
            }
            if (entity.AppointmentDate == DateTime.MinValue) 
            {
                operationResult.Success = false;
                operationResult.Message = "La fecha de la cita es requerida";
                return operationResult;
            }
            try
            {
                Appointments? appointmentToRemove = await _medicalContext.Appointments.FirstOrDefaultAsync(a => a.AppointmentID == entity.AppointmentID);

                if (appointmentToRemove == null)
                {
                    operationResult.Success = false;
                    operationResult.Message = "La cita no existe";
                    return operationResult;
                }
                appointmentToRemove.StatusID = 0;
                appointmentToRemove.UpdatedAt = DateTime.Now;

                operationResult = await base.Update(appointmentToRemove);
            }
            catch (Exception ex) 
            {
                operationResult.Success = false;
                operationResult.Message = "Error eliminado la cita.";
                logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }
        public async override Task<OperationResult> GetAll()
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                operationResult.Data = await (from appointment in _medicalContext.Appointments
                                              where appointment.IsActive == true
                                              orderby appointment.AppointmentDate descending
                                              select new AppointmentsModel()
                                              {
                                                  AppointmentID = appointment.AppointmentID,
                                                  AppointmentDate = appointment.AppointmentDate,
                                                  PatientID = appointment.PatientID,
                                                  DoctorID = appointment.DoctorID,
                                                  StatusID = appointment.StatusID,
                                                  CreatedAt = appointment.CreatedAt,
                                                  UpdatedAt = appointment.UpdatedAt,
                                                  
                                                

                                              }).ToListAsync();

            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Error obteniendo los datos de la cita";
                logger.LogError(operationResult.Message, ex.ToString());

            }
            return operationResult;
        }
        public async override Task<OperationResult> GetEntityBy(int Id)
        {
            OperationResult operationResult = new OperationResult();

            try
            {
                operationResult.Data = await (from appointments in _medicalContext.Appointments
                                              join doctoravailability in _medicalContext.DoctorAvailability on appointments.DoctorID equals doctoravailability.DoctorID
                                              where appointments.IsActive == true
                                              && appointments.AppointmentID == Id
                                              select new AppointmentsModel()
                                              {
                                                  AppointmentID = appointments.AppointmentID,
                                                  DoctorID = appointments.DoctorID,
                                                  StatusID = appointments.StatusID,
                                                  CreatedAt = appointments.CreatedAt,
                                                  UpdatedAt = appointments.UpdatedAt,
                                                  PatientID = appointments.PatientID,
                                                  AppointmentDate = appointments.AppointmentDate

                                              }).FirstOrDefaultAsync(); 
                                              
            }
            catch (Exception ex)
            {
                operationResult.Success = false;
                operationResult.Message = "Error Obteniendo la cita.";
                logger.LogError(operationResult.Message, ex.ToString());
            }
            return operationResult;
        }




    }

}

