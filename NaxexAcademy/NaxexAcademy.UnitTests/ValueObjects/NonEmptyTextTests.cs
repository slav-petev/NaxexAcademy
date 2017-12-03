using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaxexAcademy.Common.Result;
using NaxexAcademy.Core;
using NaxexAcademy.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaxexAcademy.UnitTests.ValueObjects
{
    [TestClass]
    [TestCategory(Constants.TestCategories.ValueObjectsNonEmptyText)]
    public class NonEmptyTextTests
    {
        private const string SampleTextValue = "some text";

        [TestMethod]
        public void ShouldCreateNonEmptyTextWithNonEmptyValueCorrectly()
        {
            const string textValue = SampleTextValue;

            var textResult = NonEmptyText.Create(textValue);

            Assert.IsTrue(textResult.IsSuccess);
            Assert.AreEqual(textValue, textResult.Value);
        }

        [TestMethod]
        public void SholdReturnTrueWhenComparingNonEmptyTextsWithEqualValue()
        {
            var firstText = NonEmptyText.Create(SampleTextValue).Value;
            var secondText = NonEmptyText.Create(SampleTextValue).Value;

            Assert.AreEqual(firstText, secondText);
        }

        [TestMethod]
        public void ShouldReturnResultFailWhenCreatingNonEmptyTextWithNullValue()
        {
            var textResult = NonEmptyText.Create(null);

            Assert.IsTrue(textResult.IsFailure);
        }

        [TestMethod]
        public void ShouldReturnResultFailWhenCreatingNonEmptyTextWithEmptyValue()
        {
            var textResult = NonEmptyText.Create(string.Empty);

            Assert.IsTrue(textResult.IsFailure);
        }

        [TestMethod]
        public void ShouldReturnResultFailWhenCreatingNonEmptyTextWithWhitespacesOnly()
        {
            var textResult = NonEmptyText.Create("     ");

            Assert.IsTrue(textResult.IsFailure);
        }
    }
}
