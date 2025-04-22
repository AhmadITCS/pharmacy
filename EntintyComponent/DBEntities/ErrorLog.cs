using System;
using System.Collections.Generic;

namespace EntintyComponent.DBEntities;

public partial class ErrorLog
{
    public int ErrorId { get; set; }

    public string ErrorMessage { get; set; } = null!;

    public string ErrorException { get; set; } = null!;

    public string ModuleName { get; set; } = null!;

    public DateOnly TransactionDate { get; set; }

    public int? UserId { get; set; }

    public virtual User? User { get; set; }
}
