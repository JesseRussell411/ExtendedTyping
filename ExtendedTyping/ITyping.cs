using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendedTyping
{
    /// <summary>
    /// A custom typing interface.
    /// </summary>
    public interface ITyping
    {
        Type Type { get; }
        dynamic V { get; }
        object O { get; }
    }
}
