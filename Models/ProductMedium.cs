using System;
using System.Collections.Generic;

namespace smg_erp.Models
{
    public partial class ProductMedium
    {
        public int TenantId { get; set; }
        public int ProductId { get; set; }
        public int MediaId { get; set; }
        public string? Type { get; set; }
        public string? Url { get; set; }

        public virtual Product Product { get; set; } = null!;
    }
}
