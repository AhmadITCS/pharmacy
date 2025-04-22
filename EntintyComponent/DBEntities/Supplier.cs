using System;
using System.Collections.Generic;

namespace EntintyComponent.DBEntities;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string? SupplingArea { get; set; }

    public string? CompanyName { get; set; }

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
}
