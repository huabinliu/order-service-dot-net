using FluentNHibernate.Mapping;
using order_service.Domains;

namespace order_service.Infrastructures.Mappings
{
    public class OrderItemMapping : ClassMap<OrderItem>
    {
        public OrderItemMapping()
        {
            Table("order_items");
            Id(x => x.Id).GeneratedBy.Native();
            References(x => x.Order).Column("order_id");
            Map(x => x.ProductId).Column("product_id");
            Map(x => x.Amount).Column("amount");
        }
    }
}