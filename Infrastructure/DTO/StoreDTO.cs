using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
   public class StoreDTO
    {
        public int StoreId { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public int SupplierId { get; set; }

        [Required(ErrorMessage = "This field is required")]

        public int MedicineId { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public int OrginalQty { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public int RemaningQty { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public decimal ValueTex { get; set; }

        [Required(ErrorMessage = "This field is required")]

        public decimal CostPrice { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public decimal SellingPriceBeforeTax { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public decimal SellingPriceAfterTax { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public decimal MaxDiscount { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public DateTime? ProductionDate { get; set; }
        [Required(ErrorMessage = "This field is required")]

        public DateTime? ExpiryDate { get; set; }

    }
}
