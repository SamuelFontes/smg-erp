using System;
using System.Collections.Generic;

namespace smg_erp.Models
{
    public partial class Tenant
    {
        public int TenantId { get; set; }
        public string? Name { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}
