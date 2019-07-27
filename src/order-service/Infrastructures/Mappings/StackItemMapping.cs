using FluentNHibernate.Mapping;
using order_service.Domains;

namespace order_service.Infrastructures.Mappings
{
    public class StackItemMapping : ClassMap<StackItem>
    {
        public StackItemMapping()
        {
            Table("stack_items");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.ProductId).Column("product_id");
            Map(x => x.Amount).Column("amount");           
        }
    }
}