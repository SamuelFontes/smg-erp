using System;
using System.Collections.Generic;

namespace Authenticator.Domain;

public partial class Tenant
{
    public int TenantId { get; set; }

    public string? Name { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<Person> People { get; } = new List<Person>();

    public virtual ICollection<ProductType> ProductTypes { get; } = new List<ProductType>();

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
