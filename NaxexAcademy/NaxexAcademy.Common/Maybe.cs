using System;

namespace NaxexAcademy.Common
{
    public struct Maybe<T> : IEquatable<Maybe<T>>
        where T : class
    {
        private readonly T _value;
        public T Value
        {
            get
            {
                return _value ??
                    throw new InvalidOperationException(
                        "The underlying object has no value");
            }
        }

        public bool HasValue => _value != null;

        public bool HasNoValue => !HasValue;

        private Maybe(T value)
        {
            _value = value;
        }

        public override bool Equals(object other)
        {
            if (ReferenceEquals(this, other)) return true;
            if (ReferenceEquals(this, null)) return false;
            if (ReferenceEquals(other, null)) return false;
            if (this.GetType() != other.GetType()) return false;

            return base.Equals((Maybe<T>)other);
        }

        public bool Equals(Maybe<T> other)
        {
            if (this.HasNoValue && other.HasNoValue) return true;
            if (this.HasNoValue || other.HasNoValue) return false;

            return _value.Equals(other._value);
        }

        public override int GetHashCode()
        {
            return _value != null
                ? _value.GetHashCode()
                : 0;
        }

        public override string ToString()
        {
            return _value != null 
                ? _value.ToString()
                : "No Value";
        }

        public static bool operator ==(Maybe<T> first, Maybe<T> second)
        {
            return first.Equals(second);
        }

        public static bool operator !=(Maybe<T> first, Maybe<T> second)
        {
            return !(first == second);
        }

        public static Maybe<T> From(T value)
        {
            return new Maybe<T>(value);
        }
    }
}