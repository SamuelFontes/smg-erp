using System;
using System.Collections.Generic;

namespace smg_erp.Models
{
    public partial class UserProfile
    {
        public int TenantId { get; set; }
        public int ProfileId { get; set; }
        public int UserId { get; set; }

        public virtual Profile Profile { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
