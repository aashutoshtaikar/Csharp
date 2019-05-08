using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Im
    {
        private double val;
        private uint order;
        private int sign = 1;

        public double Val { get => val; set => val = value; }
        public int Sign { get => sign; }

        public uint Order {
            get {
                return order;
            }
            set {
                if (value % 2 == 0){
                    order = 0;
                    if (value % 4 != 0){
                        sign = -1;
                    }
                }
                else{ //odd
                    order = 1;
                    if (value % 3 == 0){
                        sign = -1;
                    }
                }
                Val *= Sign;
            }
        }



        public Im(double value, uint order)
        {
            Val = value;
            Order = order;
        }

        public Im(Im other)
        {
            Val = other.Val;
            Order = other.Order;
        }


        public static Im operator *(double real, Im b)
        {
            return new Im(real * b.Val, b.Order);
        }

        public static Im operator *(Im b, double real)
        {
            return real * b;
        }

        public static Im operator *(Im a, Im b)
        {
            return new Im(a.Val*b.Val, a.Order + b.Order);
        }

        public static Im operator +(Im a, Im b)
        {
            //return new Im(a.Val + b.Val, a.Order > b.Order? a.Order : b.Order);
            return new Im(a.Val + b.Val*b.Order, a.Order | b.Order);
        }

        public static Im Add(Im a, Im b)
        {
            return new Im(a + b);
        }
    }

    public class ComplexNumber
    {

        private Im im;

        private double real;

        public double Real
        {
            get
            {
               return real;
            }
            set
            {
                if (im.Order == 0) real = value + im.Val;
                else real = value;
            }
        }


        //public ComplexNumber():this(0,1,1){}
        public ComplexNumber(Im img, double real_value = 0) : this(real_value, img.Val, img.Order){ }

        public ComplexNumber(double real_value=0, double img_value=1, uint order=1)
        {
            this.im = new Im(img_value,order);
            this.Real = real_value;
        }

        public ComplexNumber Add(ComplexNumber other)
        {
            return new ComplexNumber(this.Real + other.Real, this.im.Val + other.im.Val);
        }

        public ComplexNumber Subtract(ComplexNumber other)
        {
            return new ComplexNumber(this.Real - other.Real, this.im.Val - other.im.Val);
        }

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return a.Add(b);
        }

        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return a.Subtract(b);
        }

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            double areal_breal = a.Real * b.Real;
            Im areal_bimg = new Im(a.Real*b.im.Val, b.im.Order);
            Im aimg_breal = new Im(a.im.Val*b.real, a.im.Order);
            Im aimg_bimg = new Im(a.im.Val*b.im.Val, a.im.Order + b.im.Order);

            Im img = areal_bimg + aimg_breal + aimg_bimg;

            return new ComplexNumber(img, areal_breal);
        }

        public static ComplexNumber operator /(ComplexNumber num, ComplexNumber den)
        {
            //take the conj of denominator
            ComplexNumber conj = new ComplexNumber(den.Real, -1*den.im.Val);

            //
            ComplexNumber num_conj = new ComplexNumber(num * conj);
            ComplexNumber den_conj = new ComplexNumber(den * conj);

            if (den_conj.Real == 0) throw new Exception("Math error, denominator cannot be zero, result will be infinity");

            return new ComplexNumber(num_conj.Real/den_conj.Real, num_conj.im.Val/den_conj.Real);
        }

        public ComplexNumber(ComplexNumber other)
        {
            this.real = other.real;
            this.im = other.im;
        }



        public void Print()
        {
            if (this.im.Val != 0 && this.im.Order == 1)
            {
                Console.WriteLine(this.real + "+" + this.im.Val + "i");
            }
            else Console.WriteLine(real);
        }

    }
}
