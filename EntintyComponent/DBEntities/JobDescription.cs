using System;
using System.Collections.Generic;

namespace EntintyComponent.DBEntities;

public partial class JobDescription
{
    public int JobDescriptionId { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
