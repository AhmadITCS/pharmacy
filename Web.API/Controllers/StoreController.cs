using EntintyComponent.DBEntities;
using Infrastructure.DTO;
using Microsoft.AspNetCore.Mvc;
using Reopsitre.IReopsitre;
using Reopsitre.Reopsitre;

namespace Web.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class StoreController : Controller
    {
        private readonly IStoreReopsitre _storeReopsitre;
        private readonly ISupplierReopsitre _supplierReopsitre;
        public StoreController(ISupplierReopsitre supplierReopsitre, IStoreReopsitre storeReopsitre)

        {
            _storeReopsitre = storeReopsitre;
            _supplierReopsitre = supplierReopsitre;
        }

        public IActionResult GetAllSupplier()
        {
            List<Infrastructure.DTO.SupplierDTO> suppliers = new List<Infrastructure.DTO.SupplierDTO>();
            suppliers = (from obj in _supplierReopsitre.GetAll()
                         select new Infrastructure.DTO.SupplierDTO
                         {
                             SupplierId = obj.SupplierId,
                             SupplierName = obj.SupplierName


                         }).ToList();

            return Ok(suppliers);
        }
        public IActionResult AddnewStore(Infrastructure.DTO.StoreDTO storeDTO) {
            {
                try {
                    EntintyComponent.DBEntities.Store obj = new EntintyComponent.DBEntities.Store();

                    obj.CostPrice = storeDTO.CostPrice;
                    obj.SellingPriceAfterTax = storeDTO.SellingPriceAfterTax;
                    obj.SellingPriceBeforeTax = storeDTO.SellingPriceBeforeTax;
                    obj.ExpiryDate = storeDTO.ExpiryDate;
                    obj.MaxDiscount = storeDTO.MaxDiscount;
                    obj.SupplierId = storeDTO.SupplierId;
                    obj.MedicineId = storeDTO.MedicineId;
                    obj.OrginalQty = storeDTO.OrginalQty;
                obj.ProductionDate = storeDTO.ProductionDate;
                    obj.RemaningQty = storeDTO.OrginalQty;
                    obj.ValueTex = storeDTO.ValueTex;

                _storeReopsitre.Add(obj);
                    return Ok("Success");
                }
                catch (Exception)
                {

                    return Ok("Fill");
                }


            }
        }
    } }
