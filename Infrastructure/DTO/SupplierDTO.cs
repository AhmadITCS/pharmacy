using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
   public class SupplierDTO
    {
        public int SupplierId { get; set; }

        public string SupplierName { get; set; } = null!;

        public string Mobile { get; set; } = null!;

        public string? SupplingArea { get; set; }

        public string? CompanyName { get; set; }
    }
}
