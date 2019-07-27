using System.Collections.Generic;
using System.Linq;
using NHibernate;
using order_service.Applications;
using order_service.Domains;
using order_service.Infrastructures.Repositories;
using Xunit;

namespace order_service_test
{
    public class OrderFacts : FactBase
    {
        [Fact]
        public void should_create_order()
        {
            var items = new List<StackItem>
            {
                new StackItem
                {
                    ProductId = 6,
                    Amount = 2
                }, 
                new StackItem
                {
                    ProductId = 7,
                    Amount = 5
                }
            };            
            
            var request = new OrderCreateRequest
            {
                OrderItems = new List<OrderItemCreateRequest>
                {
                    new OrderItemCreateRequest
                    {
                        ProductId = 6,
                        Amount = 1
                    },
                    new OrderItemCreateRequest
                    {
                        ProductId = 7,
                        Amount = 2
                    }
                }
            };
            
            items.ForEach(i => ResolveSession().Save(i));            

            var orderService = new OrderService(ResolveSession(), new OrderRepository(ResolveSession()), new StackItemRepository(ResolveSession()));
            orderService.CreateOrder(request);
            
            var orders = ResolveSession().Query<Order>().ToList();
            Assert.Equal(1, orders.Count);
            
            var orderItems = ResolveSession().Query<OrderItem>().ToList();
            Assert.Equal(1, orderItems.Single(i => i.ProductId == 6).Amount);
            Assert.Equal(2, orderItems.Single(i => i.ProductId == 7).Amount);

            var stackItems = ResolveSession().Query<StackItem>().ToList();
            Assert.Equal(1, stackItems.Single(i => i.ProductId == 6).Amount);
            Assert.Equal(3, stackItems.Single(i => i.ProductId == 7).Amount);
        }
    }
}