using System;

namespace Boyner.API.Entities.Base
{
    public abstract class AuditEntity : AuditEntity<int>
    {
    }
    public abstract class AuditEntity<TId> : Entity<TId> where TId : IComparable, IConvertible, IComparable<TId>, IEquatable<TId>
    {
        public DateTime CreateDate { get; protected set; }
        public DateTime? ModifyDate { get; protected set; }
        public bool IsActive { get; protected set; }
    }
}
