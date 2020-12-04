using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExtendedTyping
{
    public class BigTypeArray : ITypeArray
    {
        public BigTypeArray(IEnumerable<Type> items) => Items = items.ToArray();
        internal BigTypeArray(IReadOnlyList<Type> items) => Items = items;
        public IReadOnlyList<Type> Items { get; }
        public Type this[int i] => Items[i];

        public int Length => Items.Count;

        public IEnumerator<Type> GetEnumerator() => Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => Items.GetEnumerator();

        public static implicit operator Type[](BigTypeArray bta) => bta.Items.ToArray();
        public static implicit operator BigTypeArray(Type[] ta) => new BigTypeArray(ta);
    }
}
