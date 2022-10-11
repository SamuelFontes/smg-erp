using System;
using System.Collections.Generic;

namespace smg_erp.Models
{
    public partial class User
    {
        public User()
        {
            Tokens = new HashSet<Token>();
            UserProfiles = new HashSet<UserProfile>();
        }

        public int TenantId { get; set; }
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Nickname { get; set; }
        public string? Email { get; set; }
        public byte[]? Hash { get; set; }
        public string Salt { get; set; } = null!;

        public virtual ICollection<Token> Tokens { get; set; }
        public virtual ICollection<UserProfile> UserProfiles { get; set; }
    }
}
