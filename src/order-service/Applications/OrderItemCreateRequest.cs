namespace order_service.Applications
{
    public class OrderItemCreateRequest
    {
        public long ProductId { get; set; }
        public int Amount { get; set; }
    }
}