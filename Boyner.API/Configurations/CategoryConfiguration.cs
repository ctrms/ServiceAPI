using Boyner.API.Configurations.Base;
using Boyner.API.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boyner.API.Configurations
{
    public class CategoryConfiguration : BaseEntityConfiguration<Category>
    {
        public override void ConfigureEntity(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasMaxLength(250);
        }
    }
}
