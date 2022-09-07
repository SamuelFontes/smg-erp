using System;
using System.Collections.Generic;

namespace smg_erp.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            Products = new HashSet<Product>();
        }

        public int TenantId { get; set; }
        public int ProductTypeId { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
