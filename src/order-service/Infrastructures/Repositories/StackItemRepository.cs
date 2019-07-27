using System.Collections.Generic;
using System.Linq;
using NHibernate;
using order_service.Domains;

namespace order_service.Infrastructures.Repositories
{
    public class StackItemRepository : IStackItemRepository
    {
        private readonly ISession Session;

        public StackItemRepository(ISession session)
        {
            Session = session;
        }

        public void Update(StackItem stackItem)
        {
            Session.Update(stackItem);
            Session.Flush();
        }

        public IEnumerable<StackItem> FindByProductIds(params long[] productIds)
        {
            return Session.Query<StackItem>().Where(i => productIds.Contains(i.ProductId)).ToList();
        }
    }
}