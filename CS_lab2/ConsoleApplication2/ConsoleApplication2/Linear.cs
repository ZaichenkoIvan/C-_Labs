//Дочірний клас від Series, який реалізує лінійне рівняння
using System;

namespace ConsoleApplication2
{
    public class Linear : Solution
    {
        public Linear(){}

        public Linear(double a, double b) : base(a, b)
        {
            Calculation(a, b);
        }
        
        public override double Calculation(double a, double b)
        {
            if (a==0 )
                throw new DivideZeroExeption();
            result = -b / a;
            return result;
        }

        public override void ToString()
        {
            Console.WriteLine("Is Linear : " + a + "x + " + b + " = 0");
            Console.WriteLine("Result of Linear is " + result);
        }

    }
}