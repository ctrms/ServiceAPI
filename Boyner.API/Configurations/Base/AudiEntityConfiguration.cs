using Boyner.API.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace Boyner.API.Configurations.Base
{
    public abstract class AudiEntityConfiguration<TEntity> : AuditEntityTypeConfiguration<TEntity, int> where TEntity : AuditEntity<int>
    {

    }
    public abstract class AuditEntityTypeConfiguration<TEntity, TId> : BaseEntityConfiguration<TEntity, TId>
        where TEntity : AuditEntity<TId>
        where TId : IComparable, IConvertible, IComparable<TId>, IEquatable<TId>
    {
        public override void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.CreateDate).IsRequired();
            builder.HasQueryFilter(p => p.IsActive);
            builder.Property(p => p.CreateDate).IsRequired();
            builder.Property(p => p.CreateDate).HasDefaultValueSql("GETDATE()").IsRequired();
            builder.Property(p => p.IsActive).HasDefaultValue(true).IsRequired();
        }
    }
}
