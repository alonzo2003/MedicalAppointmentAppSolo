
using MedicalAppointApp.Domain.Entities.Appointment;
using MedicalAppointment.Application.Base;
using MedicalAppointment.Application.Contracts;
using MedicalAppointment.Application.Dtos.Appointment.DoctorAvailability;
using MedicalAppointment.Application.Responses.Appointment.DoctorAvailability;
using MedicalappointmentApp.Persistance.Interfaces.Appointment;
using Microsoft.Extensions.Logging;

namespace MedicalAppointment.Application.Services.Appointment
{
    public class DoctorAvailabilityService : IDoctorAvailabilityService
    {
        private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;
        private readonly ILogger<DoctorAvailabilityService> _logger;

        public DoctorAvailabilityService(IDoctorAvailabilityRepository doctorAvailabilityRepository,
                                         ILogger<DoctorAvailabilityService> logger)
        {
            if (doctorAvailabilityRepository is null)
            {
                throw new ArgumentNullException(nameof(doctorAvailabilityRepository));
            }

            _doctorAvailabilityRepository = doctorAvailabilityRepository;
            _logger = logger;
        }
        public async Task<DoctorAvailabilityResponse> GetAll()
        {
            DoctorAvailabilityResponse doctorAvailabilityResponse = new DoctorAvailabilityResponse();

            try
            {
                var result = await _doctorAvailabilityRepository.GetAll();

                if (!result.Success)
                {
                    doctorAvailabilityResponse.Message = result.Message;
                    doctorAvailabilityResponse.IsSuccess = result.Success;
                    return doctorAvailabilityResponse;
                }
                doctorAvailabilityResponse.Data = result.Data;
            }

            catch (Exception ex)
            {
                doctorAvailabilityResponse.IsSuccess = false;
                doctorAvailabilityResponse.Message = "Error obteniendo las disponibilidades del doctor";
                _logger.LogError(doctorAvailabilityResponse.Message, ex.ToString());
            }

            return doctorAvailabilityResponse;
        }

        public async Task<DoctorAvailabilityResponse> GetById(int Id)
        {
            DoctorAvailabilityResponse doctorAvailabilityResponse = new DoctorAvailabilityResponse();
            try
            {
                var result = await _doctorAvailabilityRepository.GetEntityBy(Id);

                if (!result.Success)
                {
                    doctorAvailabilityResponse.Message = result.Message;
                    doctorAvailabilityResponse.IsSuccess = result.Success;
                    return doctorAvailabilityResponse;
                }
                doctorAvailabilityResponse.Data = result.Data;
            }
            catch (Exception ex)
            {
                doctorAvailabilityResponse.IsSuccess = false;
                doctorAvailabilityResponse.Message = "Error obteniendo las disponibilidades ";
                _logger.LogError(doctorAvailabilityResponse.Message, ex.ToString());
            }
            return doctorAvailabilityResponse;

        }

        public async Task<DoctorAvailabilityResponse> SaveAsync(DoctorAvailabilitySaveDto dto)
        {
            DoctorAvailabilityResponse doctorAvailabilityResponse = new DoctorAvailabilityResponse();

            try
            {
                DoctorAvailability doctorAvailability = new DoctorAvailability();
                 
                doctorAvailability.DoctorID = dto.DoctorID;
                doctorAvailability.AvailableDate = dto.AvailableDate;
                doctorAvailability.CreatedAt = dto.CreatedAt;
                doctorAvailability.StartTime = dto.StartTime;
                doctorAvailability.EndTime = dto.EndTime;

                var result = await _doctorAvailabilityRepository.Save(doctorAvailability);

            }
            catch (Exception ex) {

                doctorAvailabilityResponse.IsSuccess = false;
                doctorAvailabilityResponse.Message = "Error guardando la disponibilidad del doctor.";
                _logger.LogError(doctorAvailabilityResponse.Message, ex.ToString());
            }
            return doctorAvailabilityResponse;
        }

        public async Task<DoctorAvailabilityResponse> UpdateAsync(DoctorAvailabilityUpdateDto dto)
        {
            DoctorAvailabilityResponse doctorAvailabilityResponse = new DoctorAvailabilityResponse();

            try
            {
                var resultGetById = await _doctorAvailabilityRepository.GetEntityBy(dto.AvailabilityID);

                if (!resultGetById.Success)
                {
                    doctorAvailabilityResponse.IsSuccess = resultGetById.Success;
                    doctorAvailabilityResponse.Message = resultGetById.Message;
                    return doctorAvailabilityResponse;
                }

                DoctorAvailability doctorAvailability = (DoctorAvailability)resultGetById.Data;

                doctorAvailability.AvailabilityID = dto.AvailabilityID;
                doctorAvailability.StartTime = dto.StartTime;
                doctorAvailability.EndTime = dto.EndTime;
                doctorAvailability.AvailableDate = dto.AvailableDate;
                doctorAvailability.UpdatedAt = dto.UpdatedAt;
                doctorAvailability.IsActive = dto.IsActive;

                var result = await _doctorAvailabilityRepository.Update(doctorAvailability);
            }
            catch (Exception ex)
            {
                doctorAvailabilityResponse.IsSuccess = false;
                doctorAvailabilityResponse.Message = "Error actualizando las disponibilidades";
                _logger.LogError(doctorAvailabilityResponse.Message, ex.ToString());
            }
            return doctorAvailabilityResponse;
        }
    }
}