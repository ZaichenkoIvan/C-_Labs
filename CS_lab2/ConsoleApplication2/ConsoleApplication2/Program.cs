//Клас реалізує 2 лабораторну роботу і тестує методи класів
using System;
using System.Collections.Generic;

namespace ConsoleApplication2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            MessageAdd Handler1 = new MessageAdd();
            MessageRemove Handler2 = new MessageRemove();
            MessageChangeData Handler3 = new MessageChangeData();
            Series ser = new Series();
            ser.eventAdd += Handler1.Message;
            ser.eventRemove += Handler2.Message;
            ser.eventChangeData += Handler3.Message;


            ser.AddSeries(new Square(2,1,-3));
            ser.AddSeries(new Linear(4,5));
            ser.AddSeries(new Square(1,5,4));
            ser.AddSeries(new Linear(4,5));
            ser.Remove(2);
            ser.ChangeData(1, 1,9); 
            Console.WriteLine();
            Console.WriteLine("Series consist of :");
            ser.Print();
            tests(ser);

        }
        public static void tests (Series ser)
        {
            Linear equation = new Linear(4,8);
            Square equation2 = new Square(4,8,4);
            if(equation.Equals(new Linear(4, 8)) && equation2.Equals(new Square(4, 8, 4)))
                Console.WriteLine("Equals is correct");
            else
                Console.WriteLine("Equals is not correct");
            
            Square equation3 = new Square(4,8,4);
            Linear equation4 = new Linear(4,8);
            if(equation==equation4 && equation2==equation3)
                Console.WriteLine("== and != is correct");
            else
                Console.WriteLine("== and != is not correct");

            if(equation.GetHashCode()== equation4.GetHashCode())
                Console.WriteLine("GetHashCode is correct");
            else
                Console.WriteLine("GetHashCode is not correct");
            

            Console.WriteLine();
            Console.WriteLine("Test DeepCopy: ");

            List<Solution> someSeries2 = new List<Solution>();
            someSeries2 = ser.DeepCopy();
            foreach (Solution element in someSeries2)
            {
                element.ToString();
                Console.WriteLine();
            }
        }
    }
 
}