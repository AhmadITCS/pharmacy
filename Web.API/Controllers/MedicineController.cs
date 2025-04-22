using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Reopsitre.IReopsitre;
using Reopsitre.Reopsitre;
using System.Collections.Generic;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class MedicineController : Controller
    {
        private readonly IMedicineReopsitre _medicine;
        private readonly IMedicineDepartmentReopsitre _medicineDepartmentReopsitre;

        public MedicineController(IMedicineReopsitre medicine, IMedicineDepartmentReopsitre medicineDepartmentReopsitre )
        {
            _medicine = medicine;
            _medicineDepartmentReopsitre= medicineDepartmentReopsitre;
        }

        public IActionResult GetAllMedicine()
        {
            try
            {
                List<Infrastructure.DTO.MedicineDTO> medicineDTO = new List<Infrastructure.DTO.MedicineDTO>();
                medicineDTO = (from obj in _medicine.Find(x => x.MedicineId != 0, x => x.MedicineDepartment)
                             select new Infrastructure.DTO.MedicineDTO
                         {
                             MedicineName = obj.MedicineName,
                             MedicineDepartmentName = obj.MedicineDepartment.DepartmentName,
                             Description = obj.Description,
                             MedicineId = obj.MedicineId,

                         }).ToList();
                string jsonstring = JsonConvert.SerializeObject(medicineDTO, Formatting.None, new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                });
                return Ok(jsonstring);
            }
            catch (Exception ex) {
                return Ok(ex.Message);
            }

        }
        public IActionResult GetAllMedicineDepartment() {
            try { 
            
           List<Infrastructure.DTO.MedicineDepartmentDTO> lis = new List<Infrastructure.DTO.MedicineDepartmentDTO>();
                lis = (from obj in _medicineDepartmentReopsitre.GetAll()
                       select new Infrastructure.DTO.MedicineDepartmentDTO {

                           MedicineDepartmentId = obj.MedicineDepartmentId,
                           DepartmentName = obj.DepartmentName,
                       }).ToList();
            string jsonstring = JsonConvert.SerializeObject(lis, Formatting.None, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Ok(jsonstring);
            }
            catch (Exception ex) {
                return Ok(ex.Message);
            }
            


        }
        public IActionResult AddnewMedicine(Infrastructure.DTO.MedicineDTO medicineDTO)
        {
            try
            {
                EntintyComponent.DBEntities.Medicine obj = new EntintyComponent.DBEntities.Medicine();
                
                obj.MedicineName = medicineDTO.MedicineName;
                obj.MedicineDepartmentId = medicineDTO.MedicineDepartmentId;
                obj.Description = medicineDTO.Description;
              
                _medicine.Add(obj);
                return Ok("Success");
            }
            catch (Exception)
            {

                return Ok("Fill");
            }
           
        }
        public IActionResult GetMedicine()
        {
            List<Infrastructure.DTO.MedicineDTO> medicineDTOs = new List<Infrastructure.DTO.MedicineDTO>();
                medicineDTOs = (from obj in _medicine.GetAll() select new Infrastructure.DTO.MedicineDTO
                {
                    MedicineId = obj.MedicineId,
                    MedicineName = obj.MedicineName
                } ).ToList();

            return Ok(medicineDTOs); 
                }

    }
}
