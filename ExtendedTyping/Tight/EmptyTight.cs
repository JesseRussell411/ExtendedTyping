using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendedTyping
{
    class Tight : ITight
    {
        public IEnumerable<Type> RequiredTypes => new TypeArray();
        private Tight(dynamic v) => V = V;
        public Type Type => null;
        public dynamic V { get; }
        public object O => V;
        public static Tight New<U>(U v) => new Tight(v);
        public Tight MakeNew<U>(U v) => new Tight(v);
    }
}
