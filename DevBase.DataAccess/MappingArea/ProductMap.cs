using DevBase.Entities.Tangible;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DevBase.DataAccess.MappingArea
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(I => I.ProductId);
            builder.Property(I => I.ProductId).UseIdentityColumn();
            builder.Property(I => I.ProductName).HasMaxLength(20).IsRequired();
            builder.Property(I => I.ProductPrice).IsRequired();
        }
    }
}