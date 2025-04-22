using System;
using System.Collections.Generic;

namespace EntintyComponent.DBEntities;

public partial class Store
{
    public int StoreId { get; set; }

    public int SupplierId { get; set; }

    public int MedicineId { get; set; }

    public int OrginalQty { get; set; }

    public int RemaningQty { get; set; }

    public decimal CostPrice { get; set; }

    public decimal SellingPriceBeforeTax { get; set; }

    public decimal SellingPriceAfterTax { get; set; }

    public decimal MaxDiscount { get; set; }

    public DateTime? ProductionDate { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public decimal ValueTex { get; set; }

    public virtual Medicine Medicine { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
