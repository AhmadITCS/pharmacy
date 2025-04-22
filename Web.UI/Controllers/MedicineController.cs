using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Web.UI.Controllers
{
    public class MedicineController : Controller
    {
        public async Task<IActionResult> Creat()
        {
            HttpClient client = new HttpClient();
            var respons = await client.GetAsync("http://localhost:5044/api/Medicine/GetAllMedicineDepartment");
            var Apirespons= await respons.Content.ReadAsStringAsync();  
            
            if (respons.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ViewBag.JobeDescription = JsonConvert.DeserializeObject<List<Infrastructure.DTO.MedicineDepartmentDTO>>(Apirespons);
                return View();
            }
            else
            {
                return RedirectToAction("ErorrPage", "Home");
            }

        }
        public async Task<IActionResult> AddnewMedicine(Infrastructure.DTO.MedicineDTO medicineDTO)
        {
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(medicineDTO);
            var respons = await client.PostAsync("http://localhost:5044/api/Medicine/AddnewMedicine", new StringContent(json, Encoding.UTF8, "application/json"));
            if (respons.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok("User added successfully");
            }
            else
            {
                Console.WriteLine("Error: " + respons.StatusCode);
                return StatusCode((int)respons.StatusCode);

            }
           
        }
        public async Task<IActionResult> GetAllMedicine()
        {
           
            HttpClient client = new HttpClient();
            var respons = await client.GetAsync("http://localhost:5044/api/Medicine/GetAllMedicine");
            string apiRespons = await respons.Content.ReadAsStringAsync();

            var rselt = JsonConvert.DeserializeObject<List<Infrastructure.DTO.MedicineDTO>>(apiRespons);


            return View(rselt);
           
        }
    }
}
