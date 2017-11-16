using System;

namespace MK6.Tools.CakeBuild.Frosting
{
    public class ValidateResult
    {
        public bool Success { get; }
        public AggregateException Exception { get; }

        public ValidateResult(bool success, AggregateException exception)
        {
            Success = success;
            Exception = exception;
        }
    }
}