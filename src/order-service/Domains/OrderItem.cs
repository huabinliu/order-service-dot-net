namespace order_service.Domains
{
    public class OrderItem
    {
        public virtual long Id { get; set; }
        public virtual long ProductId { get; set; }
        public virtual Order Order { get; set; }  
        public virtual int Amount { get; set; }
    }
}