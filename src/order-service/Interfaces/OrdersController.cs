using Microsoft.AspNetCore.Mvc;
using order_service.Applications;

namespace order_service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        // POST api/orders
        [HttpPost]
        public void Post(OrderCreateRequest request)
        {
            _orderService.CreateOrder(request);
        }
    }
}