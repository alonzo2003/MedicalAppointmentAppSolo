using MedicalAppointApp.Domain.Entities.Appointment;
using MedicalAppointment.Application.Contracts;
using MedicalAppointment.Application.Dtos.Appointment.Appointments;
using MedicalappointmentApp.Persistance.Interfaces.appointment;
using Microsoft.AspNetCore.Mvc;



namespace MedicalAppointmentApp.Appointment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentsService _appointmentsService;

        public AppointmentsController(IAppointmentsService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        [HttpGet("GetAppointments")]
        public async Task<IActionResult> Get()
        {
            var result = await _appointmentsService.GetAll();

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpGet("GetAppointmentsById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _appointmentsService.GetById(id);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


        [HttpPost("SaveAppointment")]
        public async Task<IActionResult> Post([FromBody] AppointmentsSaveDto appointmentsSaveDto)
        {
            var result = await _appointmentsService.SaveAsync(appointmentsSaveDto);


            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


        [HttpPut("UpdateAppointment")]
        public async Task<IActionResult> Put([FromBody] AppointmentsUpdateDto appointmentsUpdate)
        {
            var result = await _appointmentsService.UpdateAsync(appointmentsUpdate);

            if (!result.IsSuccess)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }


    }
}
