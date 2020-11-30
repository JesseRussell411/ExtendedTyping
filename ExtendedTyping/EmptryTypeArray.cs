using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExtendedTyping
{
    public struct TypeArray : IEnumerable<Type>
    {
        public IEnumerator<Type> GetEnumerator() => Enumerable.Empty<Type>().GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}
