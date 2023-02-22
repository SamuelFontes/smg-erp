using System;
using System.Collections.Generic;

namespace Orders.Domain
{
    public partial class Order
    {
        public Order()
        {
            OrderItems = new HashSet<OrderItem>();
        }

        public int TenantId { get; set; }
        public int OrderId { get; set; }
        public int PersonId { get; set; }
        public DateTime? DateCreated { get; set; }
        public bool? IsClosed { get; set; }
        public DateTime? DateClosed { get; set; }
        public bool? IsCanceled { get; set; }
        public DateTime? DateCanceled { get; set; }

        public virtual Person Person { get; set; } = null!;
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
