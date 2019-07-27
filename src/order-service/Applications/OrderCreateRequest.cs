using System.Collections.Generic;

namespace order_service.Applications
{
    public class OrderCreateRequest
    {
        public List<OrderItemCreateRequest> OrderItems { get; set; }
    }
}