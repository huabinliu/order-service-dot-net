using System.Collections.Generic;
using FluentNHibernate.Mapping;
using order_service.Domains;

namespace order_service.Infrastructures.Mappings
{
    public class OrderMapping : ClassMap<Order>
    {
        public OrderMapping()
        {
            Table("orders");
            Id(x => x.Id).GeneratedBy.Native();
            HasMany(x => x.Items)
                .Table("order_items")
                .KeyColumn("order_id")
                .Cascade.AllDeleteOrphan()
                .Inverse()
                .LazyLoad();
        }
    }
}