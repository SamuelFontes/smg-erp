using System;
using System.Collections.Generic;

namespace smg_erp.Models
{
    public partial class OrderItem
    {
        public int TenantId { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int ProductId { get; set; }
        public decimal? Price { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Order Order { get; set; } = null!;
    }
}
