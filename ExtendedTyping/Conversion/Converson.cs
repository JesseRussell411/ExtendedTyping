using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExtendedTyping.Conversion
{
    public static class Conversion
    {
        public static T[] MakeArray<T>(this T self) => new T[] { self };
        public static T[] MakeArray<T>(params T[] items) => items;
        public static IEnumerable<T> Enumerate<T>(this T item) => new MonoEnu<T>(item);
    }
}
