using System;
using NaxexAcademy.Common.Result;
using NaxexAcademy.Core.Errors;

namespace NaxexAcademy.Core
{
    public class NonEmptyText
    {
        public string Value { get; }

        private NonEmptyText(string value)
        {
            this.Value = value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(this, null)) return false;
            if (ReferenceEquals(other, null)) return false;
            if (this.GetType() != other.GetType()) return false;

            var otherText = (NonEmptyText)other;
            return this.Value.Equals(otherText.Value);
        }

        public override int GetHashCode()
        {
            return this.Value.GetHashCode();
        }

        public static implicit operator string(NonEmptyText text)
        {
            return text.Value;
        }

        public static ValueResult<NonEmptyText> Create(string textValue)
        {
            if (string.IsNullOrWhiteSpace(textValue))
                return ValueResult<NonEmptyText>.Fail(
                    ErrorMessages.NonEmptyText.TextValueCannotBeEmpty);

            return ValueResult<NonEmptyText>.Ok(
                new NonEmptyText(textValue));
        }
    }
}