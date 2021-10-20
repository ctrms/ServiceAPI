using Boyner.API.Entities.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Boyner.API.Configurations.Base
{
    public abstract class BaseEntityConfiguration<TEntity> : BaseEntityConfiguration<TEntity, int> where TEntity : Entity<int>
    {

    }
    public abstract class BaseEntityConfiguration<TEntity, TId> : IEntityTypeConfiguration<TEntity> where TEntity : Entity<TId>
        where TId : IComparable, IConvertible, IComparable<TId>, IEquatable<TId>
    {
        public abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(p => p.Id);
            ConfigureEntity(builder);
        }
    }
}
