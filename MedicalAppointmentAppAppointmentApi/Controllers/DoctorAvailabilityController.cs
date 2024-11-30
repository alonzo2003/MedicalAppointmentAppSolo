using MedicalAppointApp.Domain.Entities.Appointment;
using MedicalAppointment.Application.Contracts;
using MedicalAppointment.Application.Dtos.Appointment.DoctorAvailability;
using MedicalappointmentApp.Persistance.Interfaces.Appointment;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointmentApp.Appointment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAvailabilityController : ControllerBase
    {
        private readonly IDoctorAvailabilityService _doctorAvailabilityService;

        public DoctorAvailabilityController(IDoctorAvailabilityService doctorAvailabilityService)
        {
            
            _doctorAvailabilityService = doctorAvailabilityService;
        }

        [HttpGet("GetDoctorAvailability")]
        public async Task<IActionResult> Get()
        {
            var result = await _doctorAvailabilityService.GetAll();

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        
        [HttpGet("GetDoctoravailabilityById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _doctorAvailabilityService.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        
        [HttpPost("SaveDoctorAvailability")]
        public async Task<IActionResult> Post([FromBody] DoctorAvailabilitySaveDto doctorAvailabilitySaveDto)
        {
            var result = await _doctorAvailabilityService.SaveAsync(doctorAvailabilitySaveDto);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        
        [HttpPut("UpdateDoctoravailability")]
        public async  Task<IActionResult> Put([FromBody] DoctorAvailabilityUpdateDto doctorAvailabilityUpdateDto)
        {
            var result = await _doctorAvailabilityService.UpdateAsync(doctorAvailabilityUpdateDto);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }

    }
}
