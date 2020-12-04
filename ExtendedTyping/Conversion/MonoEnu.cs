using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ExtendedTyping.Conversion
{
    /// <summary>
    /// An immutable enumerable struct that stores an enumerates over a single item.
    /// </summary>
    /// <typeparam name="T">The type of the item stored.</typeparam>
    public struct MonoEnu<T> : IEnumerable<T>
    {
        /// <summary>
        /// The item stored
        /// </summary>
        public readonly T Value;

        public MonoEnu(T value) => Value = value;

        public IEnumerator<T> GetEnumerator() { yield return Value; }

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public static implicit operator T(MonoEnu<T> self) => self.Value;
        public static implicit operator MonoEnu<T>(T t) => new MonoEnu<T>(t);
    }
}
