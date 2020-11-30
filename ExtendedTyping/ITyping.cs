using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendedTyping
{
    public interface ITyping
    {
        Type Type { get; }
        dynamic V { get; }
        object O { get; }
    }
}
