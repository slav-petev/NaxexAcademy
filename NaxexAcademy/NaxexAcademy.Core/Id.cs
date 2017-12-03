using NaxexAcademy.Common.Result;
using NaxexAcademy.Core.Errors;
using System;

namespace NaxexAcademy.Core
{
    public class Id
    {
        public int Value { get; }

        private Id(int value)
        {
            this.Value = value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(this, null)) return false;
            if (ReferenceEquals(other, null)) return false;
            if (this.GetType() != other.GetType()) return false;

            var otherId = (Id)other;

            return this.Value.Equals(otherId.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public static implicit operator int(Id value)
        {
            return value.Value;
        }

        public static ValueResult<Id> Create(int value)
        {
            if (value <= 0)
                return ValueResult<Id>.Fail(
                    ErrorMessages.Id.IdCannotBeNonPositive);

            return ValueResult<Id>.Ok(new Id(value));
        }
    }
}