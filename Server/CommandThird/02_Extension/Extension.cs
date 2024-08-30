using Command._04_BizDomain.Common.Error;
using System;
using System.Collections.Generic;

namespace Command._02_Extension
{
    internal static class Extension
    {
        public static bool vIsNull<T>(this T t)
        {
            return t == null;
        }

        public static bool vIsEmpty<T>(this T t)
        {
            if (t == null)
            {
                throw new NullReferenceException();
            }

            if (t is string str)
            {
                return str == "";
            }

            return t.Equals(default(T));
        }

        public static bool vIsNotEmpty<T>(this T t)
        {
            return !t.vIsEmpty();

        }

        public static bool vIsDefault<T>(this T t)
        {
            return t.Equals(default(T));
        }

        public static bool vIsNotEmpty<T>(this List<T> t)
        {
            return t.Count > 0;
        }

        public static void vAddError(this List<ErrorItem> errors, Exception exception)
        {
            ErrorItem item = Error.Mapping(exception);
            errors.Add(item);
        }
    }
}
