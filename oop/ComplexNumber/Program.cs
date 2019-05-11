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
            cn x = new cn(1, 2); //this is a complex number 1+2i
            cn y = new cn(3, 4); //3+4i

            cn somecom = new cn(1, 2) + new cn(3, 4);
            somecom.Print();

            cn a = x - y; //(1+2i) - (3+4i)
            a.Print();

            a = new cn(1, 2) * new cn(3, 4); //(1 + 2i) *(3 + 4i)
            a.Print();

            a = x / y; //(1+2i) / (3+4i) 
            a.Print();

            Console.Read();
        }
    }
}
