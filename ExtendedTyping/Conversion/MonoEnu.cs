using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExtendedTyping.Conversion
{
    public struct MonoEnu<T> : IEnumerable<T>
    {
        public T Value;
        public MonoEnu(T value) => Value = value;

        public IEnumerator<T> GetEnumerator() { yield return Value; }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public T this[int i]
        {
            get
            {
                if (i == 0) return Value;
                else throw new IndexOutOfRangeException();
            }
            set
            {
                if (i == 0) Value = value;
                else throw new IndexOutOfRangeException();
            }
        }

        public int Length => 1;

        public static implicit operator T(MonoEnu<T> self) => self.Value;
        public static implicit operator MonoEnu<T>(T t) => new MonoEnu<T>(t);
    }
}
