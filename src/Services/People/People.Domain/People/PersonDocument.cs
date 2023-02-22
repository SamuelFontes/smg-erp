using System;
using System.Collections.Generic;

namespace People.Domain
{
    public partial class PersonDocument
    {
        public int TenantId { get; set; }
        public int PersonId { get; set; }
        public int DocumentId { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual Person Person { get; set; } = null!;
    }
}
