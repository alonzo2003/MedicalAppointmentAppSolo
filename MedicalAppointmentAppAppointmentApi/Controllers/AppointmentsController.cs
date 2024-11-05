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
               return BadRequest(result);
            

            return Ok(result);
        }

        // GET api/<AppointmentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<AppointmentsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<AppointmentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AppointmentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
