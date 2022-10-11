using System;
using System.Collections.Generic;

namespace smg_erp.Models
{
    public partial class Profile
    {
        public Profile()
        {
            UserProfiles = new HashSet<UserProfile>();
        }

        public int TenantId { get; set; }
        public int ProfileId { get; set; }
        public string? ProfileName { get; set; }

        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
