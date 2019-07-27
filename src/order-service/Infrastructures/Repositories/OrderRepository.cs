using NHibernate;
using order_service.Domains;

namespace order_service.Infrastructures.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ISession Session;

        public OrderRepository(ISession session)
        {
            Session = session;
        }

        public void Create(Order model)
        {
            Session.Save(model);
            Session.Flush();
        }
    }
}