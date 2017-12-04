using System;
using NaxexAcademy.Common.Result;
using NaxexAcademy.Core.ValueObjects;
using NaxexAcademy.Common;

namespace NaxexAcademy.Core.Entities
{
    public class Student : Entity
    {
        public NonEmptyText Name { get; }
        
        private Student(NonEmptyText name)
        {
            Name = name;
        }

        private Student(Id id, NonEmptyText name)
        {
            Id = Maybe<Id>.From(id);
            Name = name;
        }

        public static ValueResult<Student> Create(string name)
        {
            var nameResult = NonEmptyText.Create(name);
            if (nameResult.IsFailure)
                return ValueResult<Student>.Fail(nameResult.Error);

            return ValueResult<Student>.Ok(new Student(nameResult.Value));
        }

        public static ValueResult<Student> Create(string name, int id)
        {
            var idResult = ValueObjects.Id.Create(id);
            if (idResult.IsFailure)
                return ValueResult<Student>.Fail(idResult.Error);
            var studentResult = Create(name);
            if (studentResult.IsFailure)
                return ValueResult<Student>.Fail(studentResult.Error);

            return ValueResult<Student>.Ok(new Student(idResult.Value,
                studentResult.Value.Name));
        }
    }
}