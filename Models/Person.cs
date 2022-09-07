using System;
using System.Collections.Generic;

namespace smg_erp.Models
{
    public partial class Person
    {
        public Person()
        {
            Orders = new HashSet<Order>();
            PersonDocuments = new HashSet<PersonDocument>();
        }

        public int TenantId { get; set; }
        public int PersonId { get; set; }
        public string? Name { get; set; }
        public DateTime? DateCreated { get; set; }
        public long? DiscordUserId { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<PersonDocument> PersonDocuments { get; set; }
    }
}
