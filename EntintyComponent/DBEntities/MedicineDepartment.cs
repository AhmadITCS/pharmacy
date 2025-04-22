using System;
using System.Collections.Generic;

namespace EntintyComponent.DBEntities;

public partial class MedicineDepartment
{
    public int MedicineDepartmentId { get; set; }

    public string DepartmentName { get; set; } = null!;

    public virtual ICollection<Medicine> Medicines { get; set; } = new List<Medicine>();
}
