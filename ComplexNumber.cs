using System;

namespace Laba3_Complex_Number
{
    class ComplexNumber
    {
        private double modulP;
        private double argumentNum;
        private double realPart;        
        private double imaginaryPart;  

        public ComplexNumber(double a, double b)
        {
            realPart = a;
            imaginaryPart = b;
            ModulP = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
            ArgumentNum = ArgumentNumMethod(a, b);
        }

        public double ModulP { get => modulP; private set => modulP = value; }
        public double ArgumentNum { get => argumentNum; private set => argumentNum = value; }
        private double ArgumentNumMethod(double a, double b)
        {
            if (a > 0)
            {
                return Math.Atan(b / a);
            }
            else if (a < 0 && b > 0)
            {
                return Math.PI + Math.Atan(b / a);
            }
            else return -Math.PI + Math.Atan(b / a);
        }

        public static ComplexNumber Pow(ComplexNumber first, double n)
        {
            return new ComplexNumber(Math.Round(Math.Cos(first.ArgumentNum * n)* Math.Pow(first.ModulP, n),2), Math.Round(Math.Sin(first.ArgumentNum * n)* Math.Pow(first.ModulP, n),2));
        }

        public override string ToString()
        {
            return string.Format($"Комплексное число - {realPart}+{imaginaryPart}*i" +
                $"\nМодуль комплексного числа = {Math.Round(ModulP,2)}" +
                $"\nАргумент комплекного числа = {Math.Round(ArgumentNum*57,2)}" +
                $"\nТригонометрическая форма - {Math.Round(ModulP, 2)}*(cos({Math.Round(ArgumentNum * 57, 2)})+i*sin({Math.Round(ArgumentNum * 57, 2)})))" +
                $"\nПоказательная форма - {Math.Round(ModulP, 2)}*e^(i*{Math.Round(ArgumentNum * 57, 2)})");
        }

        public static ComplexNumber operator+(ComplexNumber first,ComplexNumber second)
        {
            return new ComplexNumber(first.realPart+second.realPart,first.imaginaryPart+second.imaginaryPart);
        }

        public static ComplexNumber operator -(ComplexNumber first, ComplexNumber second)
        {
            return new ComplexNumber(first.realPart - second.realPart, first.imaginaryPart - second.imaginaryPart);
        }

        public static ComplexNumber operator *(ComplexNumber first, ComplexNumber second)
        {
            return new ComplexNumber(Math.Round(first.realPart * second.realPart - first.imaginaryPart * second.imaginaryPart,2), Math.Round(first.realPart * second.imaginaryPart + first.imaginaryPart * second.realPart,2));
        }

        public static ComplexNumber operator /(ComplexNumber first, ComplexNumber second)                                  
        {                                                                                                                  
            return  first * new ComplexNumber(Math.Round(second.realPart*(1d/second.ModulP),2),Math.Round(-second.imaginaryPart*(1d/second.ModulP),2)); 
        }
    }
}
