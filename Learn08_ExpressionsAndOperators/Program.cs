using System.Reflection;

namespace Learn8_ExpressionsAndOperators
{
    internal class Program
    {   


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            // var t = typeof(TempClass);
            // var fields = t.GetFields();
            // var methods = t.GetMethods();
            // var properties = t.GetProperties();
            // var constructors = t.GetConstructors();vo
            // var events = t.GetEvents();
            // var members = t.GetMembers();
            // var nestedTypes = t.GetNestedTypes();
            // var interfaces = t.GetInterfaces();
            // var attributes = t.GetCustomAttributes();
            // var baseType = t.BaseType;
            //
            // foreach (var f in fields)
            // {
            //     Console.WriteLine($"Field: {f.Name}");
            // }
            //
            // foreach (var m in methods)
            // {
            //     Console.WriteLine($"Method: {m.Name}");
            // }

            var x1 = new TempClass2();
            var x2 = new TempStruct();

            Console.WriteLine(x1++);
            Console.WriteLine(x2++);
        }

        public class TempClass
        {
            private int _tempInt;
            internal int TempInt1;
            public int TempInt2;

            private void Method1()
            {

            }

            public int Method2()
            {
                return 0;
            }
        }

        class TempClass2
        {
            private int _x;
            public int X => _x;

            public static TempClass2 operator ++(TempClass2 x)
            {
                x._x++;
                return x;
            }

            public override string ToString()
            {
                return _x.ToString();
            }
        }

        struct TempStruct
        {
            private int _x;
            public int X => _x;

            public static TempStruct operator ++(TempStruct x)
            {
                x._x++;
                return x;
            }

            public override string ToString()
            {
                return _x.ToString();
            }
        }
    }
}