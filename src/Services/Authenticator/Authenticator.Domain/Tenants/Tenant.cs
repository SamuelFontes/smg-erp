namespace Authenticator.Domain;
using System;
using System.Collections.Generic;
public partial class Tenant
{
    public int TenantId { get; set; }
    public string? Name { get; set; }
    public DateTime? DateCreated { get; set; }

    public virtual TenantSecrect TenantSecrect { get; set; } = null!;
}