
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

                doctorAvailabilityResponse.IsSuccess = result.Success;
                doctorAvailabilityResponse.Model = result.Data;
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
                doctorAvailabilityResponse.Model = result.Data;
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

                var result = _doctorAvailabilityRepository.Save(doctorAvailability);

                doctorAvailabilityResponse.Message = "";
            }
            catch (Exception ex) {
                doctorAvailabilityResponse.IsSuccess = false;
                doctorAvailabilityResponse.Message = "Error guardando la disponibilidad.";
                _logger.LogError(doctorAvailabilityResponse.Message, ex.ToString());
            }
            return doctorAvailabilityResponse;
        }

        public Task<DoctorAvailabilityResponse> UpdateAsync(DoctorAvailabilityUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}