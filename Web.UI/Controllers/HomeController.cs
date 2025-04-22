using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Web.UI.Models;

namespace Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async  Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();
            var respons = await client.GetAsync("http://localhost:5044/api/Dashboard/GetNmberOfExpiryMedicines");
            var Apirespons = await respons.Content.ReadAsStringAsync();

            if (respons.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Infrastructure.DTO.DashboardDTO dashboardDTO = JsonConvert.DeserializeObject<Infrastructure.DTO.DashboardDTO>(Apirespons);
                
                ViewBag.Medicine = dashboardDTO.MedicineCount;
                ViewBag.Suppler= dashboardDTO.SupplierCount;
                return View();
            }
            else
            {

            }
            {
                return RedirectToAction("ErorrPage", "Home");
            }
           
        }
        public IActionResult ErorrPage()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
