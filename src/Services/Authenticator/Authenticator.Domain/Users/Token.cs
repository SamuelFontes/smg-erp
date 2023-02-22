using System;
using System.Collections.Generic;

namespace Authenticator.Domain;
public partial class Token
{
    public int TenantId { get; set; }
    public int UserId { get; set; }
    public int TokenId { get; set; }
    public string Token1 { get; set; } = null!;
    public DateTime LoginDate { get; set; }
    public DateTime ExpireDate { get; set; }

    public virtual User User { get; set; } = null!;
}