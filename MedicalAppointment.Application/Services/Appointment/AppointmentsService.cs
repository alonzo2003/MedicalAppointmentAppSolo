
using MedicalAppointApp.Domain.Entities.Appointment;
using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Contracts;
using MedicalAppointment.Application.Dtos.Appointment.Appointments;
using MedicalAppointment.Application.Responses.Appointment.Appointments;
using MedicalappointmentApp.Persistance.Interfaces.appointment;
using MedicalappointmentApp.Persistance.Models.Appointment;
using Microsoft.Extensions.Logging;
using System.ComponentModel.DataAnnotations;

namespace MedicalAppointment.Application.Services.Appointment
{
    public class AppointmentsService : IAppointmentsService
    {
        private readonly IAppointmentsRepository _appointmentsRepository;
        private readonly ILogger<AppointmentsService> _logger;

        public AppointmentsService(IAppointmentsRepository appointmentsRepository,
                                   ILogger<AppointmentsService> logger)
        {
            _appointmentsRepository = appointmentsRepository;
            _logger = logger;
        }
        public async Task<AppointmentsResponse> GetAll()
        {
            AppointmentsResponse appointmentsResponse = new AppointmentsResponse();

            try
            {
                var result = await _appointmentsRepository.GetAll();

                if (!result.Success)
                {
                    appointmentsResponse.Message = result.Message;
                    appointmentsResponse.IsSuccess = result.Success;
                    return appointmentsResponse;
                }
                appointmentsResponse.Data = result.Data;


            }
            catch (Exception ex)
            {
                appointmentsResponse.IsSuccess = false;
                appointmentsResponse.Message = "Error obteniendo las citas";
                _logger.LogError(appointmentsResponse.Message, ex.ToString());
            }
            return appointmentsResponse;
        }

        public async Task<AppointmentsResponse> GetById(int Id)
        {
            AppointmentsResponse appointmentsResponse = new AppointmentsResponse();

            try
            {
                var result = await _appointmentsRepository.GetEntityBy(Id);

                

                if (!result.Success)
                {
                    appointmentsResponse.Message = result.Message;
                    appointmentsResponse.IsSuccess = result.Success;
                    return appointmentsResponse;
                }
                appointmentsResponse.Data = result.Data;
            }
            catch (Exception ex)
            {
                appointmentsResponse.IsSuccess = false;
                appointmentsResponse.Message = "Error obteniendo las citas";
                _logger.LogError(appointmentsResponse.Message, ex.ToString());
            }
            return appointmentsResponse;
        }

        public async Task<AppointmentsResponse> SaveAsync(AppointmentsSaveDto dto)
        {
            AppointmentsResponse appointmentsResponse = new AppointmentsResponse();

            try
            {
                Appointments appointments = new Appointments();

                appointments.CreatedAt = dto.CreatedAt;
                appointments.AppointmentDate = dto.AppointmentDate;
                appointments.PatientID = dto.PatientID;
                appointments.DoctorID = dto.DoctorID;

                var result = await _appointmentsRepository.Save(appointments);

            }
            catch (Exception ex)
            {
                appointmentsResponse.IsSuccess = false;
                appointmentsResponse.Message = "Error guardando la cita";
                _logger.LogError(appointmentsResponse.Message, ex.ToString());
            }
            return appointmentsResponse;

        }

        public async Task<AppointmentsResponse> UpdateAsync(AppointmentsUpdateDto dto)
        {
            AppointmentsResponse appointmentsResponse = new AppointmentsResponse();

            try
            {
                var resultGetById = await _appointmentsRepository.GetEntityBy(dto.AppointmentID);

                if (!resultGetById.Success) 
                {
                    appointmentsResponse.IsSuccess= resultGetById.Success;
                    appointmentsResponse.Message = resultGetById.Message;
                    return appointmentsResponse;
                }


                Appointments appointments = (Appointments)resultGetById.Data;

                appointments.AppointmentID = dto.AppointmentID;
                appointments.AppointmentDate = dto.AppointmentDate; 
                appointments.PatientID = dto.PatientID;
                appointments.DoctorID = dto.DoctorID;
                appointments.UpdatedAt = dto.UpdatedAt;
                appointments.StatusID = dto.StatusID;

                var result = await _appointmentsRepository.Update(appointments);

            }
            catch (Exception ex)
            {
                appointmentsResponse.IsSuccess = false;
                appointmentsResponse.Message = "Error actualizando la cita";
                _logger.LogError(appointmentsResponse.Message, ex.ToString());
            }
            return appointmentsResponse;
        }
    }
}
