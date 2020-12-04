using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using ExtendedTyping.Conversion;

namespace ExtendedTyping
{
    public static class TypeArrayUtils
    {
        public static ITypeArray ToITypeArray(this IEnumerable<Type> self) => new BigTypeArray(self.ToArray());
        internal static ITypeArray ToTypeArray(this IReadOnlyList<Type> self) => new BigTypeArray(self);
        public static IEnumerable<Type> GetParents(this Type self) => self.BaseType.Enumerate().Concat(self.GetInterfaces());
        public static IEnumerable<Type> GetSelfAndParents(this Type self) => self.Enumerate().Concat(self.GetParents());
    }
}
