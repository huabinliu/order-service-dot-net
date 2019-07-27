using System.Collections.Generic;

namespace order_service.Domains
{
    public interface IStackItemRepository
    {
        void Update(StackItem stackItem);
        IEnumerable<StackItem> FindByProductIds(params long[] productIds);
    }
}