namespace order_service.Domains
{
    public interface IOrderRepository
    {
        void Create(Order order);
    }
}