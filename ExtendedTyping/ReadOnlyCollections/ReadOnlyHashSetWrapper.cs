using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace ExtendedTyping
{
    /// <summary>
    /// Read only wrapper for a provided set. Provides methods for reading the set.
    /// </summary>
    /// <typeparam name="T">The type for the set.</typeparam>
    public struct ReadOnlySetWrapper<T> : ISet<T>
    {
        ISet<T> items;
        public bool Contains(T item) => items.Contains(item);
        public bool SetEqauls(IEnumerable<T> items) => this.items.SetEquals(items);
        public int Count => items.Count;

        public bool IsReadOnly => true;

        public void CopyTo(T[] array, int arrayIndex) => items.CopyTo(array, arrayIndex);
        public bool IsSubsetOf(IEnumerable<T> other) => items.IsSubsetOf(other);

        public bool Overlaps(IEnumerable<T> other) => items.Overlaps(other);

        public override bool Equals(object obj) => items.Equals(obj);
        public override int GetHashCode() => items.GetHashCode();
        public override string ToString() => items.ToString();

        public IEnumerator<T> GetEnumerator() => (IEnumerator<T>)items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => items.GetEnumerator();

        public bool Add(T item)
        {
            throw new NotSupportedException();
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            throw new NotSupportedException();
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            throw new NotSupportedException();
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            return  items.IsProperSubsetOf(other);
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            return items.IsProperSubsetOf(other);
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            return items.IsSubsetOf(other);
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            return items.SetEquals(other);
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            throw new NotSupportedException();
        }

        public void UnionWith(IEnumerable<T> other)
        {
            throw new NotSupportedException();
        }

        void ICollection<T>.Add(T item)
        {
            throw new NotSupportedException();
        }

        public void Clear()
        {
            throw new NotSupportedException();
        }

        public bool Remove(T item)
        {
            throw new NotSupportedException();
        }

        public ReadOnlySetWrapper(ISet<T> items) => this.items = items;

        public static implicit operator ReadOnlySetWrapper<T>(HashSet<T> items) => new ReadOnlySetWrapper<T>(items);
        public static implicit operator ReadOnlySetWrapper<T>(SortedSet<T> items) => new ReadOnlySetWrapper<T>(items);
    }
}
