using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundConsoleApp
{
    class Delegates
    {

        //        class Program
        //{
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            MathOp opA = Add;
            MathOp opB = Subtract;

            List<MathOp> operations = new();
            operations.Add(opA);
            operations.Add(opB);

            ClaculateAndPrint(3, 4, opA);

            FromDelegateToLambda();

            var result = PlaygroundMathLib.MathUtils.Add(1, 2);
            Console.WriteLine(result);

            CombineAndPrint(true, true, (x, y) => x && y);
        }

        public static void FromDelegateToLambda()
        {
            ClaculateAndPrint(2, 5, delegate (int x, int y) { return x * y; });  // from delegate
            ClaculateAndPrint(2, 5, (int x, int y) => { return x * y; });
            ClaculateAndPrint(2, 5, (int x, int y) => x * y);
            ClaculateAndPrint(2, 5, (x, y) => x * y);                           // to lambda function

        }

        delegate T Combine<T>(T x, T y);
        delegate int MathOp(int x, int y);

        static void ClaculateAndPrint(int x, int y, MathOp operation)
        {
            var result = operation(x, y);
            Console.WriteLine(result);
        }

        static void CombineAndPrint<T>(T x, T y, Combine<T> operation)
        {
            var result = operation(x, y);
            Console.WriteLine(result);
        }

        static int Add(int x, int y)
        {
            return x + y;
        }
        static int Subtract(int a, int b)
        {
            return a - b;
        }
    }
    //}
}
