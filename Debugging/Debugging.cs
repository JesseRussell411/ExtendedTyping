using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using ExtendedTyping;


namespace Debugging
{
    class Program
    {
        static void Main(string[] args)
        {
            int getInt(Loose<int, string, double, bool> loos)
            {
                return loos.V switch
                {
                    int i => i,
                    double d => (int)d,
                    string s => int.TryParse(s, out int result) ? result : -1,
                    bool b => b ? 1 : 0,
                    _ => -1,
                };
            }

            Loose<long, double, decimal> uberNum = 5;


            Console.WriteLine(uberNum);
            uberNum = 9.3;
            Console.WriteLine(uberNum);
            uberNum = 4.9M;
            Console.WriteLine(uberNum);
            //uberNum = "a number..."; // *won't even compile.

            Loose<long, double> uberNum2 = 8;


            Console.WriteLine(getInt(6)); // *sure
            Console.WriteLine(getInt(6.7)); // *yeah
            Console.WriteLine(getInt("6")); // *no problem
            Console.WriteLine(getInt("b")); // *ok
            Console.WriteLine(getInt(true));// *alright
            //Console.WriteLine(getInt(new ContextStaticAttribute())); // *nope, won't even compile because the type checking is done at compile time.

            //Loose<bool, char> bc = "hello world"; // *can't do it!
            Loose<string, StringBuilder> s = new StringBuilder();
            ((StringBuilder)s).Append("Hel");
            s.V.Append("lo");
            (s.V as StringBuilder)?.Append(" World");


            Console.WriteLine(s);
            Console.WriteLine(s.V.GetType());
            s = s.ToString();

            (s = new StringBuilder(s.V)).V.Append(", bob");
            Console.WriteLine(s);
            Console.WriteLine(s.V.GetType());

            Loose<bool, int> adsf = true;
            bool b = (bool)adsf;
            Console.WriteLine(b);


            Loose<Foo, int> foo = new Bar() { foo = "Hello ", bar = "World!" };
            Console.WriteLine(((Foo)foo).ToStr());

            //foo = 9;
            //Console.WriteLine(foo);
            //Foo foo3 = (Foo)foo;
            //Console.WriteLine(foo3);


            Loose<int, long> il = 9;
            Console.WriteLine(il == 9);
            Console.WriteLine(il == 5);
            Console.WriteLine(il != 5);
            Console.WriteLine(il != 9);
            //long l = (long)il;

            ITight t = Tight<IComparable<int>, IEquatable<int>>.New(9);
            BigLoose bl = new BigLoose(new Type[] { typeof(int), typeof(double) });

            bl.V = 8;
            Console.WriteLine(bl);
            var bl2 = bl.Clone();

            Console.WriteLine(bl == bl2);
            Console.WriteLine(bl != bl2);
            Console.WriteLine(bl == 8);
            Console.WriteLine(bl == 5);
            Console.WriteLine(bl != 5);
            Console.WriteLine(bl != 8);
            Console.WriteLine(bl.GetHashCode());
            Console.WriteLine(bl2.GetHashCode());
            IEnumerable ie = new TypeArray<int, string, long, bool, ulong, long, uint, short, ushort, byte, sbyte, char>()
                .Concat(new TypeArray<StringBuilder, Stopwatch, DateTime, Loose<int>, Loose<double>, int, string, bool, int, int, int, int, int>());


            foreach (Type type in ie)
            {
                Console.WriteLine(type);
            }

            Console.WriteLine("-----");

            foreach (Type type in new TypeArray<int>())
            {
                Console.WriteLine(type);
            }

        }
    }

    class Foo
    {
        public string foo;
        public virtual string ToStr() => foo;
    }

    class Bar : Foo
    {
        public string bar;
        public override string ToStr() => foo + bar;
    }

}
