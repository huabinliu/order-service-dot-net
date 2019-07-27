using System.Linq;
using NHibernate;
using NHibernate.Util;
using order_service.Domains;

namespace order_service.Applications
{
    public class OrderService
    {  
        private readonly ISession _session;
        private readonly IOrderRepository _orderRepository;
        private readonly IStackItemRepository _stackItemRepository;

        public OrderService(ISession session, IOrderRepository orderRepository, IStackItemRepository stackItemRepository)
        {
            _session = session;
            _orderRepository = orderRepository;
            _stackItemRepository = stackItemRepository;
        }

        public void CreateOrder(OrderCreateRequest request)
        {
            var order = new Order
            {
                Items = request.OrderItems.Select(i => new OrderItem
                {
                    ProductId = i.ProductId,
                    Amount = i.Amount
                }).ToList()
            };

            var productIdToOrderAmount = order.Items.ToDictionary(i => i.ProductId, i => i.Amount);
            var stackItems = _stackItemRepository.FindByProductIds(productIdToOrderAmount.Keys.ToArray());
            stackItems.ForEach(i => i.Amount -= productIdToOrderAmount[i.ProductId]);
            
            using (ITransaction transaction = _session.BeginTransaction())
            {
                _orderRepository.Create(order);
                stackItems.ForEach(i => _stackItemRepository.Update(i));
                transaction.Commit();
            }
        }
    }
}