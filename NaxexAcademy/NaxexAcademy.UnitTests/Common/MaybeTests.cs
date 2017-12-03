using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaxexAcademy.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaxexAcademy.UnitTests.Common
{
    [TestClass]
    [TestCategory(Constants.TestCategories.CommonMaybe)]
    public class MaybeTests
    {
        [TestMethod]
        public void ShouldHaveValueWhenCreatedFromNonNullObject()
        {
            var maybeString = Maybe<string>.From("some value");

            Assert.IsTrue(maybeString.HasValue);
        }

        [TestMethod]
        public void ShouldHaveNoValueWhenCreatedFromNullObject()
        {
            var maybeString = Maybe<string>.From(null);

            Assert.IsTrue(maybeString.HasNoValue);
        }

        [TestMethod]
        public void UnderlyingValueShouldBeEqualToInitialValue()
        {
            var initialValue = "some value";

            var maybeString = Maybe<string>.From(initialValue);

            Assert.AreEqual(initialValue, maybeString.Value);
        }

        [TestMethod]
        public void ShouldThrowInvalidOperationExceptionWhenAccessingNonExistingValue()
        {
            var noValueMaybe = Maybe<string>.From(null);

            Assert.ThrowsException<InvalidOperationException>(() =>
                noValueMaybe.Value);
        }

        [TestMethod]
        public void ShouldGetUnderlyingObjectHashCodeWhenHasValue()
        {
            var stringValue = "some string value";
            var expectedHashCode = stringValue.GetHashCode();

            var maybeString = Maybe<string>.From(stringValue);

            Assert.AreEqual(expectedHashCode, maybeString.GetHashCode());
        }

        [TestMethod]
        public void ShouldGetZeroForHashCodeWhenHasNoValue()
        {
            var expectedHashCode = 0;

            var maybeString = Maybe<string>.From(null);

            Assert.AreEqual(expectedHashCode, maybeString.GetHashCode());
        }

        [TestMethod]
        public void ShouldNotBeEqualWhenUnderlyingTypesAreDifferent()
        {
            var maybeString = 
                Maybe<string>.From("some value");
            var maybeStringBuilder =
                Maybe<StringBuilder>.From(new StringBuilder());

            Assert.AreNotEqual(maybeString, maybeStringBuilder);
        }

        [TestMethod]
        public void ShouldBeEqualWhenUnderlyingTypesAreEqual()
        {
            var stringValue = "some string value";
            var firstMaybe = Maybe<string>.From(stringValue);
            var secondMaybe = Maybe<string>.From(stringValue);

            Assert.AreEqual(firstMaybe, secondMaybe);
        }

        [TestMethod]
        public void ShouldNotBeEqualWhenUnderlyingTypesAreNotEqual()
        {
            var firstStringValue = "some string value";
            var secondStringValue = "some other value";
            var firstMaybe = Maybe<string>.From(firstStringValue);
            var secondMaybe = Maybe<string>.From(secondStringValue);

            Assert.AreNotEqual(firstMaybe, secondMaybe);
        }
    }
}
