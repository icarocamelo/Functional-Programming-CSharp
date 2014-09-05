using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Delegates
            //First implementation
            Bubblesorter.IsAGreaterThanBDelegate compareInt = delegate(object a, object b)
            {
                return ((int)a > (int)b);
            };

            //First implementation
            Bubblesorter.IsAGreaterThanBDelegate compareInt2 = (object a, object b) =>
            {
                return ((int)a > (int)b);
            };

            //Third implementation
            Bubblesorter.IsAGreaterThanBDelegate compareInt3 = (a, b) => ((int)a > (int)b);

            //Fourth implementation
            Func<object, object, Boolean> compareInt4 = (a, b) => ((int)a > (int)b);

            //Calling
            Console.WriteLine(compareInt(3, 1));
            #endregion
            #region Generics functions
            List<int> integers = new List<int>() { 0, 5, 3, 1, 10 };

            //Calling generics functions #1
            Bubblesorter.Echo<string>("Test");

            //Calling generics functions #2
            Bubblesorter.Echo<int>(1);

            //Calling generics functions #3
            Bubblesorter.Apply(integers, Action());

            //Calling generics functions #4
            Bubblesorter.Apply(integers, i => Console.WriteLine(i));
            #endregion

            var value = Bubblesorter.curriedAdd.Invoke(10);
            Console.WriteLine(value.Invoke(2));

            Console.ReadKey();
        }

       

        private static Action<int> Action()
        {
            return i => Console.WriteLine(i);
        }
        
        public class Bubblesorter
        {
            public delegate bool IsAGreaterThanBDelegate(object a, object b);

            //Currying example with lambda expressions
            public static Func<int, Func<int, Func<int,int>>> curriedAdd = x => y => z => x + y + z;

            //Currying example with anonymous delegates
            public static Func < int, Func < int, int > > CurriedAdd =
                delegate(int x) {
                    return delegate(int y)
                    {
                        return x + y;
                    };
                };
            
            public static T Echo<T>(T type)
            {
                return type;
            }

            public static void Apply<T>(IEnumerable<T> sequence, Action<T> action)
            {
                foreach (T item in sequence)
                {
                    action(item);
                }
            }
        }
    }
}
