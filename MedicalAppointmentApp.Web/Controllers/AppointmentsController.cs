using MedicalAppointment.Application.Contracts;
using MedicalAppointment.Application.Dtos.Appointment.Appointments;
using MedicalAppointment.Application.Dtos.Appointment.DoctorAvailability;
using MedicalappointmentApp.Persistance.Models.Appointment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentApp.Web.Controllers
{
    public class AppointmentsController : Controller
    {
        private readonly IAppointmentsService _appointmentsService;

        public AppointmentsController(IAppointmentsService appointmentsService)
        {
            _appointmentsService = appointmentsService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _appointmentsService.GetAll();

            if (result.IsSuccess && result.Data != null)
            {
                List<AppointmentsModel> appointmentsModels = (List<AppointmentsModel>)result.Data;
                return View(appointmentsModels);
            }
            return View(new List<AppointmentsModel>());
        }


        public async Task<IActionResult> Details(int id)
        {
            var result = await _appointmentsService.GetById(id);

            if (result.IsSuccess && result.Data != null)
            {
                AppointmentsModel appointmentsModel = (AppointmentsModel)result.Data;

                return View(appointmentsModel);
            }
            ViewBag.Message = "No Availability records found";
            return RedirectToAction(nameof(Index));
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentsSaveDto appointmentsSave)
        {
            try
            {
                appointmentsSave.CreatedAt = DateTime.Now;
                var result = await _appointmentsService.SaveAsync(appointmentsSave);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            var result = await _appointmentsService.GetById(id);

            if (result.IsSuccess)
            {
                AppointmentsModel appointmentsModel = (AppointmentsModel)result.Data;
                return View(appointmentsModel);
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppointmentsUpdateDto appointmentsUpdate)
        {
            try
            {
                appointmentsUpdate.UpdatedAt = DateTime.Now;
                var result = await _appointmentsService.UpdateAsync(appointmentsUpdate);
                if (result.IsSuccess)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = result.Message;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
