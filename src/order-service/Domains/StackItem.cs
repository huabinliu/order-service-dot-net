namespace order_service.Domains
{
    public class StackItem
    {
        public virtual long Id { get; set; }
        public virtual long ProductId { get; set; }
        public virtual long Amount { get; set; }
    }
}