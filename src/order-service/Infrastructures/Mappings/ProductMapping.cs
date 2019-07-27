using FluentNHibernate.Mapping;
using order_service.Domains;

namespace order_service.Infrastructures.Mappings
{
    public class ProductMapping : ClassMap<Product>
    {
        public ProductMapping()
        {
            Table("products");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Name).Column("name");
        }
    }
}