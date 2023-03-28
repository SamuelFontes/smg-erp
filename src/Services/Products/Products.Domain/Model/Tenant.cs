using System;
using System.Collections.Generic;

namespace Products.Domain.Model.Tenant;

public partial class Tenant
{
    public int TenantId { get; set; }

    public string? Name { get; set; }

    public int? ModifiedBy { get; set; }

    public DateTime? DateCreated { get; set; }

    public bool? Active { get; set; }
}