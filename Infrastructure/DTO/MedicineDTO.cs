using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class MedicineDTO
    {
        public int MedicineId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string MedicineName { get; set; } = null!;

        
        public int MedicineDepartmentId { get; set; }

        [Required(ErrorMessage = "This field is required")]
        public string Description { get; set; } = null!;
        public string MedicineDepartmentName { get; set; }  

    }
}
