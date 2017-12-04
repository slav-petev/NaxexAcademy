using NaxexAcademy.Common;
using NaxexAcademy.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaxexAcademy.Core
{
    public abstract class Entity
    {
        public Maybe<Id> Id { get; }

        public override bool Equals(object other)
        {
            var otherEntity = other as Entity;
            if (ReferenceEquals(other, null)) return false;
            if (ReferenceEquals(this, other)) return true;
            if (this.GetType() != otherEntity.GetType()) return false;
            if (this.Id.HasNoValue || otherEntity.Id.HasNoValue) return false;

            return this.Id == otherEntity.Id;
        }

        public override int GetHashCode()
        {
            return (this.GetType().ToString() + Id).GetHashCode();
        }

        public static bool operator ==(Entity first, Entity second)
        {
            if (ReferenceEquals(first, null) && ReferenceEquals(second, null))
                return true;
            if (ReferenceEquals(first, null) || ReferenceEquals(second, null))
                return false;

            return first.Equals(second);
        }

        public static bool operator !=(Entity first, Entity second)
        {
            return !(first == second);
        }
    }
}