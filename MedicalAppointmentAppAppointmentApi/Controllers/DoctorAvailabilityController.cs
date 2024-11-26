using MedicalAppointApp.Domain.Entities.Appointment;
using MedicalappointmentApp.Persistance.Interfaces.Appointment;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalAppointmentApp.Appointment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAvailabilityController : ControllerBase
    {
        private readonly IDoctorAvailabilityRepository _doctorAvailabilityRepository;

        public DoctorAvailabilityController(IDoctorAvailabilityRepository doctorAvailabilityRepository)
        {
            _doctorAvailabilityRepository = doctorAvailabilityRepository;

        }

        [HttpGet("GetDoctorAvailability")]
        public async Task<IActionResult> Get()
        {
            var result = await _doctorAvailabilityRepository.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        
        [HttpGet("GetDoctoravailabilityById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _doctorAvailabilityRepository.GetEntityBy(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        
        [HttpPost("SaveDoctorAvailability")]
        public async Task<IActionResult> Post([FromBody] DoctorAvailability doctorAvailability)
        {
            var result = await _doctorAvailabilityRepository.Save(doctorAvailability);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        
        [HttpPut("UpdateDoctoravailability")]
        public async  Task<IActionResult> Put([FromBody] DoctorAvailability doctorAvailability)
        {
            var result = await _doctorAvailabilityRepository.Update(doctorAvailability);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);

        }
        [HttpPost("DisableDoctoravailability")]

        public async Task<IActionResult> DisableDoctoravailability(DoctorAvailability doctorAvailability)
        {
            var result = await _doctorAvailabilityRepository.Remove(doctorAvailability);

            if (!result.Success)
             return BadRequest(result); 
            return Ok(result);
        }

    }
}
