using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    class ComplexNumber
    {
        private double im;
        private uint order;
        private int sign = 1;

        public double Im { get => im; set => im = value; }
        public int Sign { get => sign; }

        public uint Order
        {
            get
            {
                return order;
            }
            set
            {
                if (value % 2 == 0)
                {
                    order = 0;
                    if (value % 4 != 0)
                    {
                        sign = -1;
                    }
                }
                else
                { //odd
                    order = 1;
                    if (value % 3 == 0)
                    {
                        sign = -1;
                    }
                }
                Im *= Sign;
            }
        }

        private double real;

        public double Real
        {
            get
            {
               return real;
            }
            set
            {
                if (Order == 0)
                {
                    real = value + im;
                    this.Im = 0;
                }
                else real = value;
            }
        }

        public ComplexNumber(double real_value=0, double img_value=1, uint order=1)
        {
            this.im = img_value;
            this.Order = order;
            this.Real = real_value;
        }

        public ComplexNumber(ComplexNumber other)
        {
            this.real = other.real;
            this.im = other.im;
            this.order = other.order;
        }

        public ComplexNumber Add(ComplexNumber other)
        {
            return new ComplexNumber(this.Real + other.Real, this.Im + other.Im);
        }

        public ComplexNumber Subtract(ComplexNumber other)
        {
            return new ComplexNumber(this.Real - other.Real, this.Im - other.Im);
        }

        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real + b.Real, a.Im + b.Im, a.Order | b.Order);
        }

        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return a.Subtract(b);
        }

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            ComplexNumber areal_breal = new ComplexNumber(a.Real * b.Real,0,0);
            ComplexNumber areal_bimg = new ComplexNumber(0, a.Real * b.Im, b.Order);
            ComplexNumber aimg_breal = new ComplexNumber(0, a.Im * b.real, a.Order);
            ComplexNumber aimg_bimg = new ComplexNumber(0, a.Im * b.Im, a.Order + b.Order);

            ComplexNumber sum = areal_breal + areal_bimg + aimg_breal + aimg_bimg; //order is 0?

            return sum;
        }

        public static ComplexNumber operator /(ComplexNumber num, ComplexNumber den)
        {
            //take the conj of denominator
            ComplexNumber conj = new ComplexNumber(den.Real, -1*den.Im);

            //
            ComplexNumber num_conj = new ComplexNumber(num * conj);
            ComplexNumber den_conj = new ComplexNumber(den * conj);

            if (den_conj.Real == 0) throw new Exception("Math error, denominator cannot be zero, result will be infinity");

            return new ComplexNumber(num_conj.Real/den_conj.Real, num_conj.Im/den_conj.Real);
        }





        public void Print()
        {
            if (this.im != 0 && this.Order == 1)
            {
                Console.WriteLine(this.Real + "+" + this.Im + "i");
            }
            else Console.WriteLine(this.Real);
        }

    }
}
