using Boyner.API.Configurations.Base;
using Boyner.API.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boyner.API.Configurations
{
    public class ProductConfiguration : AudiEntityConfiguration<Product>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(250);
        }
    }
}
