
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;


namespace Web.UI.Controllers
{
    public class UsersController : Controller
    {
        public async Task<IActionResult> Creat()
        {
            HttpClient client = new HttpClient();
            var respones = await client.GetAsync("http://localhost:5044/api/Users/GetAllIJobDescription");
            string apirespons = await respones.Content.ReadAsStringAsync();
          
            

            if (respones.StatusCode == System.Net.HttpStatusCode.OK)
            {
                ViewBag.JobeDescription = JsonConvert.DeserializeObject<List<Infrastructure.DTO.JobeDescriptionDTO>>(apirespons);
          return View();
            }
            else
            {
                return RedirectToAction("ErorrPage","Home");
            }
            
        }
        public async Task<IActionResult> Addnewuser(Infrastructure.DTO.UserDTO userDTO)
        {
           
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(userDTO);
            var response = await client.PostAsync("http://localhost:5044/api/Users/Addnewuser", new StringContent(json, Encoding.UTF8, "application/json"));

            //string apiResponse = await response.Content.ReadAsStringAsync();
            //Console.WriteLine("API Response: " + apiResponse);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return Ok("User added successfully");
            }
            else
            {
                Console.WriteLine("Error: " + response.StatusCode);
                return StatusCode((int)response.StatusCode);

            }
        }


        public async Task<IActionResult> GetAllUsers()
        {
            HttpClient client = new HttpClient();
            var respons = await client.GetAsync("http://localhost:5044/api/Users/GetAllUsers");
            string apiRespons = await respons.Content.ReadAsStringAsync();

            var rselt = JsonConvert.DeserializeObject<List<Infrastructure.DTO.UserDTO>>(apiRespons);

            return View(rselt);
        }
        public async Task<IActionResult> Delete(int UserId)
        {
            HttpClient client = new HttpClient();
            var respons = await client.DeleteAsync("http://localhost:5044/api/Users/Delete?UserId=" + UserId);
            if (respons.StatusCode == System.Net.HttpStatusCode.OK) {

                return RedirectToAction("GetAllUsers");
            }
            else {
                return View();
            }
            
        }
        public async Task<IActionResult> Edit(int UserId)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync("http://localhost:5044/api/Users/GetUserByid?UserId=" + UserId);

            string apiRespons = await response.Content.ReadAsStringAsync();
            Infrastructure.DTO.UserDTO userDTO = JsonConvert.DeserializeObject<Infrastructure.DTO.UserDTO>(apiRespons);

            //var responesJop = await client.GetAsync("http://localhost:5044/api/Users/GetAllIJobDescription");
            //string apiresponsJop = await responesJop.Content.ReadAsStringAsync();

            //ViewBag.JobeDescription = JsonConvert.DeserializeObject<List<Infrastructure.DTO.JobeDescriptionDTO>>(apiresponsJop);
            //if (userDTO == null)
            //{
            //    return NotFound();
            //}
            ViewBag.JobeDescription = userDTO.Description;
            return View(userDTO);
            }
        public async Task<IActionResult> UpdateUser(Infrastructure.DTO.UserDTO userDTO)
        {
            HttpClient client = new HttpClient();
            var json = JsonConvert.SerializeObject(userDTO);
            var response = await client.PostAsync("http://localhost:5044/api/Users/UpdateUser", new StringContent(json, Encoding.UTF8, "application/json"));
           
            return RedirectToAction("GetAllUsers");
        }


        }
    
}
