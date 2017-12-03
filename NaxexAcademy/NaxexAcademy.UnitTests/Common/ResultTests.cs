using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaxexAcademy.Common;
using NaxexAcademy.Common.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaxexAcademy.UnitTests.Common
{
    [TestClass]
    [TestCategory(Constants.TestCategories.CommonResult)]
    public class ResultTests
    {
        [TestMethod]
        public void ShouldCreateResultCorrectly()
        {
            var expectedResult = Result.Ok();

            Assert.IsNotNull(expectedResult);
        }

        [TestMethod]
        public void ShouldThrowInvalidOperationExceptionWhenTryingToAssignErrorToSuccessResult()
        {
            Assert.ThrowsException<ArgumentException>(() =>
                new Result(true, "some error message"));
        }

        [TestMethod]
        public void ShouldThrowArgumentExceptionWhenCreatingFailedResultWithNoError()
        {
            var invalidErrors = new List<string>
            {
                null,
                string.Empty,
                "      "
            };

            invalidErrors.ForEach(invalidError =>
                Assert.ThrowsException<ArgumentException>(() =>
                    new Result(false, string.Empty)));
        }

        [TestMethod]
        public void ShouldThrowInvalidOperationExceptionWhenTryingToAccessValueOfFailedResult()
        {
            var failedResult = ValueResult<int>.Fail("some error message");
            Assert.ThrowsException<InvalidOperationException>(() =>
                failedResult.Value);
        }

        [TestMethod]
        public void ShouldGetValueCorrectlyForSuccessResult()
        {
            var okResult = ValueResult<int>.Ok(int.MinValue);

            Assert.AreEqual(int.MinValue, okResult.Value);
        }

        [TestMethod]
        public void ShouldContainNoErrorWhenResultIsSuccess()
        {
            string expectedError = null;

            var successResult = Result.Ok();

            Assert.AreEqual(expectedError, successResult.Error);
        }

        [TestMethod]
        public void ShouldContainErrorWhenResultIsFailure()
        {
            var error = "some error message";

            var failedResult = Result.Fail(error);

            Assert.AreEqual(error, failedResult.Error);
        }
    }
}
