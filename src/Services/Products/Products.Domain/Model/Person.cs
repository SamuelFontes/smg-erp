using System;
using System.Collections.Generic;

namespace Products.Infrastructure;

public partial class Person
{
    public int TenantId { get; set; }

    public int PersonId { get; set; }

    public string? Name { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }

    public DateTime? ModifiedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public bool? Active { get; set; }
}
