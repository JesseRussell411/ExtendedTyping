using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ExtendedTyping.Conversion
{
    [StructLayout(LayoutKind.Explicit)]
    public struct IntBool
    {
        [FieldOffset(0)]
        public int Int;
        [FieldOffset(0)]
        public bool Bool;

        [FieldOffset(0)]
        public bool Bool1;
        [FieldOffset(1)]
        public bool Bool2;
        [FieldOffset(2)]
        public bool Bool3;
        [FieldOffset(3)]
        public bool Bool4;

        public static implicit operator IntBool(int b) => new IntBool() { Int = b };
        public static implicit operator IntBool(bool b) => new IntBool() { Bool = b };
        public static implicit operator int(IntBool bb) => bb.Int;
        public static implicit operator bool(IntBool bb) => bb.Bool;
    }
}
