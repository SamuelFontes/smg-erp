using System;
using System.Collections.Generic;

namespace smg_erp.Models
{
    public partial class TenantSecrect
    {
        public int TenantId { get; set; }
        public string Secrect { get; set; } = null!;

        public virtual Tenant Tenant { get; set; } = null!;
    }
}
