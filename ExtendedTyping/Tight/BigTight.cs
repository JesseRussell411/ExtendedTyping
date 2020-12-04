using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ExtendedTyping
{
    public class BigTight : ITight
    {
        #region public Properties
        public IReadOnlyCollection<Type> RequiredSet => required;
        public IEnumerable<Type> RequiredTypes => required.ToITypeArray();
        /// <summary>
        /// The value stored in the current Loose type.
        /// </summary>
        public dynamic V
        {
            get => value;
            set
            {
                if (!CheckType(value.GetType())) throw new ArgumentException($"Cannot set the value to the type of {value.GetType()} because their are types in the required type set that it does not extend or implement.");
                
                this.value = value;
            }
        }
        /// <summary>
        /// The type of the value stored in the current Loose type.
        /// </summary>
        public Type Type => value.GetType();

        /// <summary>
        /// The value stored in the current Loose type in the form of an object.
        /// </summary>
        public object O => value;
        #endregion

        #region public Constructors
        private BigTight() { }
        public BigTight(IEnumerable<Type> required)
        {
            this.required = new HashSet<Type>(required);
        }
        #endregion

        #region public Methods
        /// <summary>
        /// Creates and returns a new BigTight with the same required set (borrowed) as the current BigRight and a shallow copy of it's value.
        /// </summary>
        /// <returns></returns>
        public BigTight BorrowClone()
        {
            BigTight result = new BigTight();
            result.required = required;
            result.value = value;
            return result;
        }

        /// <summary>
        /// Creates and returns a new BigTight with a copy of the required set from the current BigTight and a shallow copy of it's value.
        /// </summary>
        /// <returns></returns>
        public BigTight Clone()
        {
            BigTight result = new BigTight();
            result.required = new HashSet<Type>(required);
            result.value = value;
            return result;
        }
        public override string ToString() => value.ToString();
        public override bool Equals(object obj) => value.Equals(obj);
        public override int GetHashCode() => value.GetHashCode();

        /// <summary>
        /// Tries to set V to the value given.
        /// </summary>
        /// <param name="v">Value given.</param>
        /// <returns>True if success; False otherwise.</returns>
        public bool TrySetV(dynamic v)
        {
            if (CheckType(v.GetType()))
            {
                V = v;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckType(Type t)
        {
            HashSet<Type> t_typeset = new HashSet<Type>(t.GetSelfAndParents());
            foreach(Type r in required)
            {
                if (!t_typeset.Contains(r)) return false;
            }
            return true;
        }
        public bool AddType(Type t)
        {
            if (required.Add(t))
            {
                if (!CheckType(value)) value = default;
                return true;
            }
            else return false;
        }
        public bool RemoveType(Type t) => required.Remove(t);
        #endregion

        #region public static Methods
        #region Operators
        public static bool operator ==(BigTight left, BigTight right) => left.value.Equals(right.value);
        public static bool operator ==(BigTight left, object right) => left.value.Equals(right);
        public static bool operator ==(object left, BigTight right) => left.Equals(right.value);
        public static bool operator !=(BigTight left, BigTight right) => !left.value.Equals(right.value);
        public static bool operator !=(BigTight left, object right) => !left.value.Equals(right);
        public static bool operator !=(object left, BigTight right) => !left.Equals(right.value);
        #endregion
        #endregion

        #region private Fields
        private dynamic value;
        private HashSet<Type> required;
        #endregion
    }
}
