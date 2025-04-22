using System;
using System.Collections.Generic;

namespace EntintyComponent.DBEntities;

public partial class InvoiceDetail
{
    public int InvoiceDetailsId { get; set; }

    public int InvoiceMasterId { get; set; }

    public int MedicineId { get; set; }

    public int Qty { get; set; }

    public decimal SellingPrice { get; set; }

    public virtual InvoiceMaster InvoiceMaster { get; set; } = null!;
}
