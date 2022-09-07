using System;
using System.Collections.Generic;

namespace smg_erp.Models
{
    public partial class Product
    {
        public Product()
        {
            ProductMedia = new HashSet<ProductMedium>();
        }

        public int TenantId { get; set; }
        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? ProductTypeId { get; set; }
        public bool? Active { get; set; }

        public virtual ProductType? ProductType { get; set; }
        public virtual ICollection<ProductMedium> ProductMedia { get; set; }
    }
}
