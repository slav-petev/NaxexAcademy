using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaxexAcademy.Common.Result;
using NaxexAcademy.Core;
using NaxexAcademy.Core.Errors;
using NaxexAcademy.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public void ShouldReturnTrueWhenComparingIdsWithEqualValue()
        {
            var firstId = Id.Create(1).Value;
            var secondId = Id.Create(1).Value;

            Assert.AreEqual(firstId, secondId);
        }

        [TestMethod]
        public void ShouldReturnResultFailWhenCreatingIdWithNegativeValue()
        {
            var idResult = Id.Create(-1);

            Assert.IsTrue(idResult.IsFailure);
            Assert.AreEqual(
                ErrorMessages.Id.IdCannotBeNonPositive, idResult.Error);
        }

        [TestMethod]
        public void ShouldReturnResultFailWhenCreatingIdWithZeroValue()
        {
            var idResult = Id.Create(0);

            Assert.IsTrue(idResult.IsFailure);
            Assert.AreEqual(
                ErrorMessages.Id.IdCannotBeNonPositive, idResult.Error);
        }
    }
}
