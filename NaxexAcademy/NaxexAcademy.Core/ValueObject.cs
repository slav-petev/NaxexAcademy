using System;
using System.Collections.Generic;
using System.Text;

namespace NaxexAcademy.Core
{
    public abstract class ValueObject<T>
        where T : ValueObject<T>
    {
        public override bool Equals(object other)
        {
            var valueObject = other as T;
            if (ReferenceEquals(valueObject, null)) return false;

            return EqualsCore(valueObject);
        }

        protected abstract bool EqualsCore(T other);

        public override int GetHashCode()
        {
            return GetHashCodeCore();
        }

        protected abstract int GetHashCodeCore();
    }
}
