using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendedTyping
{
    /// <summary>
    /// Allows only items that inherit, or extend every type in the RequiredTypes list to be stored.
    /// </summary>
    public interface ITight : ITyping
    {
        IEnumerable<Type> RequiredTypes { get; }
    }
}
