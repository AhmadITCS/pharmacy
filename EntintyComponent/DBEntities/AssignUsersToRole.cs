﻿using System;
using System.Collections.Generic;

namespace EntintyComponent.DBEntities;

public partial class AssignUsersToRole
{
    public int AssignUserToRoleId { get; set; }

    public int UserId { get; set; }

    public int RoleId { get; set; }

    public virtual Role Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
