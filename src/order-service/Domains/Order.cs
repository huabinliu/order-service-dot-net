using System.Collections.Generic;

namespace order_service.Domains
{
    public class Order
    {
        public virtual long Id { get; set; }
        
        public virtual IList<OrderItem> Items { get; set; }
    }
}