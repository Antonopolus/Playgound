using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaygroundConsoleApp
{
    class Closures
    {

        int CalculateSomething(int n)
        {
            if (n == 0) return 0;
            var factor = 42;

           var s =  CreateCalculator();

            Console.WriteLine(s(5));
            Console.WriteLine(CreateCalculator()(7));

            return factor * CalculateSomething(n-1);
        }

        // higher order fnction
        Func<int,int> CreateCalculator()
        {
            var factor = 42;
            return n => n*factor;  // closure -> factor goes from stack to heap (promoted, captured)
        }
    }
}
