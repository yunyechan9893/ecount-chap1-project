using System;
using System.Collections.Generic;

namespace Command._04_BizDomain.Common.Error
{
    public static class Error
    {
        private static Dictionary<object, int> _errors = new Dictionary<object, int>()
        {
            { new ArgumentNullException(), 1001 },
            { new InvalidOperationException(), 1002 },
            { new IndexOutOfRangeException(), 1003 },
            { new NullReferenceException(), 1004 },
            { new DivideByZeroException(), 1005 }
        };

        public static ErrorItem Mapping(Exception exception)
        {
            try
            {
                return new ErrorItem(_errors[exception], exception.Message);
            }
            catch (Exception e)
            {
                return new ErrorItem(9999, e.Message);
            }
        }
    }

    public class ErrorItem
    {
        public int code { get; }
        public string message { get; }

        public ErrorItem(int code, string message)
        {
            this.code = code;
            this.message = message;
        }
    }
}
