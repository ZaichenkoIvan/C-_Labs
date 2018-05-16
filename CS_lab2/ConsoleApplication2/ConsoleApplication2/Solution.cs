//Абстрактий клас рівняння
using System;

namespace ConsoleApplication2
{
    public abstract class Solution:Object
    {
        protected double result; //результат лінійного рівняння
        public double result1; // 1 результат квадратного рівняння
        public double result2; // 2 результат квадратного рівняння
        protected double a;    // коефіцієнт для лінійного і квадратного рівняння
        protected double b;    // коефіцієнт для лінійного і квадратного рівняння
        protected double c;    // коефіцієнт для квадратного рівняння

        public Solution()
        {
            a = 0;
            b = 0;
        }
        public Solution(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public Solution(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        
        public double A
        {
            get { return a;}
            set { a = value; }
        }
        
        public double B
        {
            get { return b;}
            set { b = value; }
        }
        
        public double C
        {
            get { return c;}
            set { c = value; }
        }
        
        public double Result
        {
            get { return result; }
        }
        
        public double Result1
        {
            get { return result1; }
        }
        
        public double Result2
        {
            get { return result2; }
        }

        public bool Equals(Solution equation)
        {
            return a == equation.A && b == equation.B && c == equation.C && result1 == equation.Result1 &&
                   result2 == equation.Result2 && result == equation.Result;
        }

        public static bool operator ==(Solution equation, Solution equation2)
        {
            return equation.Equals(equation2);
        }
        
        public static bool operator !=(Solution equation, Solution equation2)
        {
            return !equation.Equals(equation2);
        }

        public override int GetHashCode()        
        {            
            return (int)a ^ (int)b;        
        }

        public abstract void ToString();
 

        public virtual double Calculation(double a, double b)
        {
            return result;}

        public virtual void Calculation(double a, double b, double c)
        {}
    }
}