using MedicalAppointment.Application.Dtos.Appointment.Appointments;
using MedicalAppointmentApp.Web.Models;
using MedicalAppointmentApp.Web.Models.Appointments;
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


        public async Task<IActionResult> Details(int id)
        {
            string url = "http://localhost:5014/api/";

            AppointmentsGetByIdModel appointmentsGetByIdModel = new AppointmentsGetByIdModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = await client.GetAsync($"Appointments/GetAppointmentsById?id={id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();
                    appointmentsGetByIdModel = JsonConvert.DeserializeObject<AppointmentsGetByIdModel>(response);
                }

            }

            return View(appointmentsGetByIdModel.Data);
        }

        // GET: AppointmentsAdmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AppointmentsAdmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(AppointmentsSaveDto appointmentsSave)
        {
            string url = "http://localhost:5014/api/";
            BaseApiResponseModel model = new BaseApiResponseModel();
            
            try
            {
                
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(url);

                    var responseTask = await client.PatchAsJsonAsync<AppointmentsSaveDto>("Appointments/SaveAppointment", appointmentsSave);

                    if (responseTask.IsSuccessStatusCode)
                    {
                        string response = await responseTask.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<BaseApiResponseModel>(response);

                        if (!model.IsSuccess)
                        {
                            ViewBag.Message = model.message;

                            return View();
                        }
                        else
                        {
                            return RedirectToAction(nameof(Index));
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AppointmentsAdmController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            string url = "http://localhost:5014/api/";
            AppointmentsGetByIdModel appointmentsGetByIdModel = new AppointmentsGetByIdModel();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);

                var responseTask = await client.GetAsync($"Appointments/GetAppointmentsById?id={id}");

                if (responseTask.IsSuccessStatusCode)
                {
                    string response = await responseTask.Content.ReadAsStringAsync();
                    appointmentsGetByIdModel = JsonConvert.DeserializeObject<AppointmentsGetByIdModel>(response);

                }
            }
            return View(appointmentsGetByIdModel.Data);
        }

        // POST: AppointmentsAdmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(AppointmentsSaveDto appointmentsSaveDto)
        {
            BaseApiResponseModel model = new BaseApiResponseModel();
            try
            {
                string url = "http://localhost:5014/api/";

                //using (var client = new HttpClient())
                //{
                //    client.BaseAddress= new Uri(url);

                //    var responseTask = await client.PutAsJsonAsync<AppointmentsUpdateDto>("Appointments/UpdateAppointment", appointmentsSaveDto);

                //    if (responseTask.IsSuccessStatusCode)
                //    {
                //        string response = await responseTask.Content.ReadAsStringAsync();

                //        model = JsonConvert.DeserializeObject<BaseApiResponseModel>(response);

                //        if (!model.IsSuccess)
                //        {
                //            ViewBag.Message = model.message;
                //            return View();

                //        }
                //        else
                //        {

                //            return RedirectToAction(nameof(Index));
                //        }
                //    }
                //}

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
