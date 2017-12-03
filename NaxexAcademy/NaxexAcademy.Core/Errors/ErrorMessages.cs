using System;
using System.Collections.Generic;
using System.Text;

namespace NaxexAcademy.Core.Errors
{
    public static class ErrorMessages
    {
        public static class Id
        {
            public const string IdCannotBeNonPositive =
                "Id cannot be zero or negative";
        }

        public static class NonEmptyText
        {
            public const string TextValueCannotBeEmpty =
                "Text value is empty or contains only whitespaces";
        }
    }
}
