using System;
using System.Collections.Generic;

namespace EntintyComponent.DBEntities;

public partial class InvoiceMaster
{
    public int InvoiceMasterId { get; set; }

    public string ReferenceNumber { get; set; } = null!;

    public DateTime TransactionDate { get; set; }

    public string CustomerName { get; set; } = null!;

    public int? NumberOfItems { get; set; }

    public decimal? TotalCostPrice { get; set; }

    public decimal? TotalSellingPrice { get; set; }

    public virtual ICollection<InvoiceDetail> InvoiceDetails { get; set; } = new List<InvoiceDetail>();
}
