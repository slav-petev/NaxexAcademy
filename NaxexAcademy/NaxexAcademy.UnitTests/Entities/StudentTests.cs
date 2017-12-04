using Microsoft.VisualStudio.TestTools.UnitTesting;
using NaxexAcademy.Common.Result;
using NaxexAcademy.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NaxexAcademy.UnitTests.Entities
{
    [TestClass]
    [TestCategory(Constants.TestCategories.EntitiesStudent)]
    public class StudentTests
    {
        [TestMethod]
        public void ShouldNotCreateStudentWithNullName()
        {
            ValueResult<Student> studentResult = Student.Create(null);

            Assert.IsTrue(studentResult.IsFailure);
        }

        [TestMethod]
        public void ShouldNotCreateStudentWithEmptyName()
        {
            ValueResult<Student> studentResult = Student.Create(string.Empty);

            Assert.IsTrue(studentResult.IsFailure);
        }

        [TestMethod]
        public void ShouldNotCreateStudentWithWhitespacesName()
        {
            ValueResult<Student> studentResult = Student.Create("   ");

            Assert.IsTrue(studentResult.IsFailure);
        }

        [TestMethod]
        public void ShouldCreateStudentWithoutId()
        {
            var studentResult = Student.Create("Sample Name");

            Assert.IsTrue(studentResult.IsSuccess);
            Assert.IsTrue(studentResult.Value.Id.HasNoValue);
        }

        [TestMethod]
        public void ShouldCreateStudentWithId()
        {
            var studentResult = Student.Create("Sample Name", 1);

            Assert.IsTrue(studentResult.IsSuccess);
            Assert.IsTrue(studentResult.Value.Id.HasValue);
        }

        [TestMethod]
        public void ShouldAddCoursePointsToTotalWhenRegistered()
        {
            
        }

        [TestMethod]
        public void ShouldNotBeAbleToRegisterForCourseWhenAlreadyRegistered()
        {

        }

        [TestMethod]
        public void ShouldNotBeAbleToRegisterForCourseIfNewTotalWillExceedAllowedPoints()
        {

        }

        [TestMethod]
        public void ShouldBeAbleToUnregisterFromCourseInWhichRegistered()
        {

        }

        [TestMethod]
        public void ShouldNotBeAbleToUnregisterFromCourseInWhichNotRegistered()
        {

        }
    }
}
