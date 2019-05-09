using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ComplexNumber
    {
        private float real;
        private float im;
        private uint imorder;

        public float Im {
            get => im;
            set => im = value;
        }
        public uint Order
        {
            get => imorder;
            set
            {
                int sign = 1;
                if (value % 2 == 0)
                {
                    imorder = 0;
                    if (value % 4 != 0)
                    {
                        sign = -1;
                    }
                }
                else
                { //odd
                    imorder = 1;
                    if (value % 3 == 0)
                    {
                        sign = -1;
                    }
                }
                Im *= sign;
            }
        }
        public float Real
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

        public ComplexNumber(float real_value=0, float img_value=1, uint order=1)
        {
            this.im = img_value;
            this.Order = order;
            this.Real = real_value;
        }

        public ComplexNumber(ComplexNumber other)
        {
            this.real = other.real;
            this.im = other.im;
            this.imorder = other.imorder;
        }


        public static ComplexNumber operator +(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real + b.Real, a.Im + b.Im, a.Order | b.Order);
        }

        public static ComplexNumber operator -(ComplexNumber a, ComplexNumber b)
        {
            return new ComplexNumber(a.Real - b.Real, a.Im - b.Im, a.Order | b.Order);
        }

        public static ComplexNumber operator *(ComplexNumber a, ComplexNumber b)
        {
            ComplexNumber areal_breal = new ComplexNumber(a.Real * b.Real,0,0);
            ComplexNumber areal_bimg = new ComplexNumber(0, a.Real * b.Im, b.Order);
            ComplexNumber aimg_breal = new ComplexNumber(0, a.Im * b.real, a.Order);
            ComplexNumber aimg_bimg = new ComplexNumber(0, a.Im * b.Im, a.Order + b.Order);

            ComplexNumber sum = areal_breal + areal_bimg + aimg_breal + aimg_bimg;

            return sum;
        }

        public static ComplexNumber operator /(ComplexNumber num, ComplexNumber den)
        {
            //take the conj of denominator(complex conjugate)
            ComplexNumber conj = new ComplexNumber(den.Real, -1*den.Im);

            ComplexNumber num_conj = new ComplexNumber(num * conj);
            ComplexNumber den_conj = new ComplexNumber(den * conj);

            if (den_conj.Real == 0) throw new Exception("Math error, denominator cannot be zero, result will be infinity");

            return new ComplexNumber(num_conj.Real/den_conj.Real, num_conj.Im/den_conj.Real);
        }

        public void Print()
        {
            if (this.im != 0 && this.Order == 1)
            {
                if (this.Real != 0)
                {
                    if (this.Im > 0) Console.WriteLine(this.Real + "+" + this.Im + "i");
                    if (this.Im < 0) Console.WriteLine(this.Real + "" + this.Im + "i");
                }
                else
                {
                    if (this.Im > 0) Console.WriteLine(this.Im + "i");
                    if (this.Im < 0) Console.WriteLine(this.Im + "i");
                }
            }
            else Console.WriteLine(this.Real);
        }

    }
}
