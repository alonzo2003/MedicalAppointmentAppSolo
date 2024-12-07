using MedicalAppointmentApp.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MedicalAppointmentApp.Web.Controllers
{
    public class AppointmentsAdmController : Controller
    {
        
        public async Task<IActionResult> Index()
        {
            string url = "http://localhost:5014/api/";

            AppointmentsGetAllResultModel appointmentsGetAllResultModel = new AppointmentsGetAllResultModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = await client.GetAsync("Appointments/GetAppointments");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();

                    appointmentsGetAllResultModel = JsonConvert.DeserializeObject<AppointmentsGetAllResultModel>(response);
                }
                else
                {
                    ViewBag.Message = "";
                }

            }

            return View(appointmentsGetAllResultModel.data);
        }

        // GET: AppointmentsAdmController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AppointmentsAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentsAdmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppointmentsAdmController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AppointmentsAdmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppointmentsAdmController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AppointmentsAdmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
