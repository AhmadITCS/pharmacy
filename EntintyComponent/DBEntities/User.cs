using System;
using System.Collections.Generic;

namespace EntintyComponent.DBEntities;

public partial class User
{
    public int UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public string Email { get; set; } = null!;

    public string MobileNumber { get; set; } = null!;

    public bool Gender { get; set; }

    public string Address { get; set; } = null!;

    public bool ShiftType { get; set; }

    public decimal Salary { get; set; }

    public int JobDescriptionId { get; set; }

    public DateOnly JoinDate { get; set; }

    public DateOnly? ResignationDate { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<AssignUsersToRole> AssignUsersToRoles { get; set; } = new List<AssignUsersToRole>();

    public virtual ICollection<ErrorLog> ErrorLogs { get; set; } = new List<ErrorLog>();

    public virtual JobDescription JobDescription { get; set; } = null!;
}
