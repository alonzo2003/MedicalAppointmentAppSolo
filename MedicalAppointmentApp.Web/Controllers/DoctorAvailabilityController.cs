using MedicalAppointment.Application.Contracts;
using MedicalAppointment.Application.Dtos.Appointment.DoctorAvailability;
using MedicalappointmentApp.Persistance.Models.Appointment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointmentApp.Web.Controllers
{
    public class DoctorAvailabilityController : Controller
    {
        private readonly IDoctorAvailabilityService _doctorAvailabilityService;

        public DoctorAvailabilityController(IDoctorAvailabilityService doctorAvailabilityService)
        {
            _doctorAvailabilityService = doctorAvailabilityService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _doctorAvailabilityService.GetAll();

            if (result.IsSuccess && result.Data != null) 
            {
                List<DoctorsAvailabilityModel> doctorsAvailabilityModels = (List<DoctorsAvailabilityModel>)result.Data;

                return View(doctorsAvailabilityModels);
            }
            return View(new List<DoctorsAvailabilityModel>());

        }


        public async Task<IActionResult> Details(int id)
        {
            var result = await _doctorAvailabilityService.GetById(id);

            if (result.IsSuccess && result.Data != null)
            {
                DoctorsAvailabilityModel doctorsAvailabilityModel = (DoctorsAvailabilityModel)result.Data;
                return View(doctorsAvailabilityModel);
            }
            return View();
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DoctorAvailabilitySaveDto doctorAvailabilitySave)
        {
            try
            {
                doctorAvailabilitySave.CreatedAt = DateTime.Now;
                var result = await _doctorAvailabilityService.SaveAsync(doctorAvailabilitySave);
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
            var result = await _doctorAvailabilityService.GetById(id);

            if (result.IsSuccess)
            {
                DoctorsAvailabilityModel doctorsAvailabilityModel = (DoctorsAvailabilityModel)result.Data;

                return View(doctorsAvailabilityModel);
            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(DoctorAvailabilityUpdateDto doctorAvailabilityUpdate)
        {
            try
            {
                doctorAvailabilityUpdate.UpdatedAt = DateTime.Now;
                var result = await _doctorAvailabilityService.UpdateAsync(doctorAvailabilityUpdate);
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
