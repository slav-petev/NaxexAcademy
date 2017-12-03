using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaxexAcademy.Core.ValueObjects;

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
        public void SholdReturnTrueWhenComparingNonEmptyTextsWithSameValue()
        {
            var firstText = NonEmptyText.Create(SampleTextValue).Value;
            var secondText = NonEmptyText.Create(SampleTextValue).Value;

            Assert.AreEqual(firstText, secondText);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenComparingNonEmptyTextsWithDifferentValue()
        {
            var firstText = NonEmptyText.Create(SampleTextValue).Value;
            var secondText = NonEmptyText.Create("another").Value;

            Assert.AreNotEqual(firstText, secondText);
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
