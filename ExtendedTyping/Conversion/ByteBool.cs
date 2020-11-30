using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ExtendedTyping.Conversion
{
    [StructLayout(LayoutKind.Explicit)]
    public struct ByteBool
    {
        [FieldOffset(0)]
        public byte Byte;
        [FieldOffset(0)]
        public bool Bool;

        public static implicit operator ByteBool(byte b) => new ByteBool() { Byte = b };
        public static implicit operator ByteBool(bool b) => new ByteBool() { Bool = b };
        public static implicit operator byte(ByteBool bb) => bb.Byte;
        public static implicit operator bool(ByteBool bb) => bb.Bool;
    }
}
