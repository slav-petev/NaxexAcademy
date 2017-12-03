using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaxexAcademy.Core.ValueObjects;

namespace NaxexAcademy.UnitTests.ValueObjects
{
    [TestClass]
    [TestCategory(Constants.TestCategories.ValueObjectsId)]
    public class IdTests
    {
        [TestMethod]
        public void ShouldCreateIdWithPositiveValueCorrectly()
        {
            var idValue = 1;

            var idResult = Id.Create(idValue);

            Assert.IsTrue(idResult.IsSuccess);
            Assert.AreEqual(idValue, idResult.Value);
        }

        [TestMethod]
        public void ShouldReturnTrueWhenComparingIdsWithSameValue()
        {
            var firstId = Id.Create(1).Value;
            var secondId = Id.Create(1).Value;

            Assert.AreEqual(firstId, secondId);
        }

        [TestMethod]
        public void ShouldReturnFalseWhenComparingIdsWithDifferentValue()
        {
            var firstId = Id.Create(1).Value;
            var secondId = Id.Create(2).Value;

            Assert.AreNotEqual(firstId, secondId);
        }

        [TestMethod]
        public void ShouldReturnResultFailWhenCreatingIdWithNegativeValue()
        {
            var idResult = Id.Create(-1);

            Assert.IsTrue(idResult.IsFailure);
        }

        [TestMethod]
        public void ShouldReturnResultFailWhenCreatingIdWithZeroValue()
        {
            var idResult = Id.Create(0);

            Assert.IsTrue(idResult.IsFailure);
        }
    }
}
