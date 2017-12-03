using NaxexAcademy.Common.Result;
using NaxexAcademy.Core.Errors;

namespace NaxexAcademy.Core.ValueObjects
{
    public class NonEmptyText : ValueObject<NonEmptyText>
    {
        public string Value { get; }

        private NonEmptyText(string value)
        {
            this.Value = value;
        }

        protected override bool EqualsCore(NonEmptyText other)
        {
            return this.Value.Equals(other.Value);
        }

        protected override int GetHashCodeCore()
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