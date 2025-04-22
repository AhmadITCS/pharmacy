using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Reopsitre.IReopsitre;
using System.Collections.Generic;

namespace Web.API.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IStoreReopsitre _storeReopsitre;
        private readonly ISupplierReopsitre _supplierReopsitre;
        public DashboardController(IStoreReopsitre storeReopsitre, ISupplierReopsitre supplierReopsitre )
        {
            _storeReopsitre = storeReopsitre;
            _supplierReopsitre = supplierReopsitre;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetNmberOfExpiryMedicines()
        {
            try { 
            Infrastructure.DTO.DashboardDTO dashboardDTO = new Infrastructure.DTO.DashboardDTO();
            dashboardDTO.MedicineCount = _storeReopsitre.Find(x =>
    x.ExpiryDate != null &&
    x.ExpiryDate.Value.Date < DateTime.Today.AddDays(30) &&
    x.ExpiryDate.Value.Date > DateTime.Today
).Count();
            dashboardDTO.SupplierCount= _supplierReopsitre.GetAll().Count();
            string jsonstring = JsonConvert.SerializeObject(dashboardDTO, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(jsonstring);
        }
            catch (Exception ex) {
                return Ok(ex.Message);
    }

          
        }

    }
}
