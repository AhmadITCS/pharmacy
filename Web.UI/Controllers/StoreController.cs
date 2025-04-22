using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Web.UI.Controllers
{
    public class StoreController : Controller
    {
        public async Task<IActionResult> Create()
        {
            HttpClient client = new HttpClient();
            var respons = await client.GetAsync("http://localhost:5044/api/Medicine/GetMedicine");
                var ApiRepons = await respons.Content.ReadAsStringAsync();
            ViewBag.Medicine = JsonConvert.DeserializeObject<List<Infrastructure.DTO.MedicineDTO>>(ApiRepons);


           
            var respons1 = await client.GetAsync("http://localhost:5044/api/Store/GetAllSupplier");
            var ApiRepons1 = await respons1.Content.ReadAsStringAsync();
            ViewBag.Supplier = JsonConvert.DeserializeObject<List<Infrastructure.DTO.SupplierDTO>>(ApiRepons1);

            return View();
        }
public async Task<IActionResult> AddnewStore(Infrastructure.DTO.StoreDTO newStore)
        {
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(newStore);
            var respons = await client.PostAsync("http://localhost:5044/api/Store/AddnewStore", new StringContent(json, Encoding.UTF8, "application/json"));
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
    }
   
}
