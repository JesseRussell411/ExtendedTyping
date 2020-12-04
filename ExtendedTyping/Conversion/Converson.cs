using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExtendedTyping.Conversion
{
    public static class Conversion
    {
        /// <summary>
        /// Creates an array with one items; that item being the parameter "self".
        /// </summary>
        /// <typeparam name="T">The type of the new array.</typeparam>
        /// <param name="self">The items to be stored in the array.</param>
        /// <returns>An array of length 1, containing the item provided.</returns>
        public static T[] MakeArray<T>(this T self) => new T[] { self };

        /// <summary>
        /// Returns an enumerable struct containing one item; that item being the parameter "item"
        /// </summary>
        /// <typeparam name="T">The type of the new enumerable struct.</typeparam>
        /// <param name="item">The item provided.</param>
        /// <returns>An enumerable struct containing the item provided.</returns>
        public static IEnumerable<T> Enumerate<T>(this T item) => new MonoEnu<T>(item);
    }
}
