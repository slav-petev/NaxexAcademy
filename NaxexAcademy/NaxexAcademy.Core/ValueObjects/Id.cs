using NaxexAcademy.Common.Result;
using NaxexAcademy.Core.Errors;
using System;

namespace NaxexAcademy.Core.ValueObjects
{
    public class Id : ValueObject<Id>
    {
        public int Value { get; }

        private Id(int value)
        {
            this.Value = value;
        }

        protected override bool EqualsCore(Id other)
        {
            return this.Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
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