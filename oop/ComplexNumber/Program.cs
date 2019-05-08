using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            ComplexNumber x = new ComplexNumber(6, 2);
            ComplexNumber y = new ComplexNumber(6, 4);

            ComplexNumber a = x + y;
            a.Print();

            a = x * y;
            a.Print();

            a = x / y;
            a.Print();

            Console.Read();
        }
    }
}
