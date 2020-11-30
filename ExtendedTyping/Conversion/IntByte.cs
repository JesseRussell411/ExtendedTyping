using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace ExtendedTyping.Conversion
{
    [StructLayout(LayoutKind.Explicit)]
    public struct IntByte
    {
        [FieldOffset(0)]
        public int Int;
        [FieldOffset(0)]
        public byte Byte;

        [FieldOffset(0)]
        public byte Byte1;
        [FieldOffset(1)]
        public byte Byte2;
        [FieldOffset(2)]
        public byte Byte3;
        [FieldOffset(3)]
        public byte Byte4;

        public static implicit operator IntByte(int b) => new IntByte() { Int = b };
        public static implicit operator IntByte(byte b) => new IntByte() { Byte = b };
        public static implicit operator int(IntByte bb) => bb.Int;
        public static implicit operator byte(IntByte bb) => bb.Byte;
    }
}
