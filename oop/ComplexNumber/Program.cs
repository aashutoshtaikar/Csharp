using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    using cn = ComplexNumber;
    class Program
    {
         
        static void Main(string[] args)
        {
            cn x = new cn(1, 2);
            cn y = new cn(3, 4);

            cn a = x - y;
            a.Print();

            a = new cn(1, 2) * new cn(3, 4);
            a.Print();

            a = x / y;
            a.Print();

            Console.Read();
        }
    }
}
