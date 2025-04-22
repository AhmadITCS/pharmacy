using System;
using System.Collections.Generic;

namespace EntintyComponent.DBEntities;

public partial class Medicine
{
    public int MedicineId { get; set; }

    public string MedicineName { get; set; } = null!;

    public int MedicineDepartmentId { get; set; }

    public string Description { get; set; } = null!;

    public virtual MedicineDepartment MedicineDepartment { get; set; } = null!;

    public virtual ICollection<Store> Stores { get; set; } = new List<Store>();
}
