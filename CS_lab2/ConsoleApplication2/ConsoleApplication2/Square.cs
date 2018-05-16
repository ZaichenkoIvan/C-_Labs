//Дочірний клас від Series, який реалізує квадратне рівняння
using System;

namespace ConsoleApplication2
{
    public class Square:Solution
    {
        private double diskriminant;
        public int count;
        public Square(){}

        public Square(double a, double b, double c) : base(a, b, c)
        {
            Calculation(a, b, c);
        }
        
        public override void Calculation(double a, double b, double c)
        {
            if (a==0)
                throw new DivideZeroExeption();
            diskriminant = b * b - 4 * c * a;
            if (diskriminant < 0)
            {
                Console.WriteLine("Diskriminant <0");
            }

            if (diskriminant == 0)
            {
                result1 = -b / (2 * a);
                count=1;
            }

            if (diskriminant > 0)
            {
                result1 = (-b - Math.Sqrt(diskriminant)) / (2 * a);
                result2 = (-b + Math.Sqrt(diskriminant)) / (2 * a);
                count = 2;
            }
        }

        
        public override void ToString()
        {
            Console.WriteLine("Is Square : " + a + "x^2 + " + b + "x + " + c + " = 0");
            if (count==0)
                Console.WriteLine("No result");
            if (count==1)
                Console.WriteLine("Result of Square is " + result1);
            if (count==2)
                Console.WriteLine("Result of Square are " + result1 + " and " + result2);
        }
    }
}