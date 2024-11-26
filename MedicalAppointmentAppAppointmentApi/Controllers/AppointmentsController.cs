using MedicalAppointApp.Domain.Entities.Appointment;
using MedicalappointmentApp.Persistance.Interfaces.appointment;
using Microsoft.AspNetCore.Mvc;



namespace MedicalAppointmentApp.Appointment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        public IAppointmentsRepository _AppointmentsRepository { get; }

        public AppointmentsController(IAppointmentsRepository appointmentsRepository)
        {
            _AppointmentsRepository = appointmentsRepository;
        }
        // GET api/<AppointmentsController>

        [HttpGet("GetAppointments")]
        public async Task<IActionResult> Get()
        {
            var result = await _AppointmentsRepository.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        
        [HttpGet("GetAppointmentsById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _AppointmentsRepository.GetEntityBy( id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
            
        }

        
        [HttpPost("SaveAppointment")]
        public async Task<IActionResult> Post([FromBody] Appointments appointments)
        {
            var result = await _AppointmentsRepository.Save(appointments);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut("UpdateAppointment")]
        public async Task<IActionResult> Put([FromBody] Appointments appointments)
        {
            var result = await _AppointmentsRepository.Update(appointments);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpPost("DisableAppointments")]

        public async Task<IActionResult> DisableAppointment(Appointments appointments)
        {
            var result = await _AppointmentsRepository.Remove(appointments);

            if (!result.Success)
             return BadRequest(result); 
            return Ok(result);
        }


    }
}
