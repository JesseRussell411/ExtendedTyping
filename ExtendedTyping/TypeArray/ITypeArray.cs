using System;
using System.Collections.Generic;
using System.Text;

namespace ExtendedTyping
{
    public interface ITypeArray : IEnumerable<Type>
    {
        Type this[int i] { get; }
        int Length { get; }
    }
}
