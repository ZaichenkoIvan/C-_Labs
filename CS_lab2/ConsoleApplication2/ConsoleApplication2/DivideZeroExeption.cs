//Клас реалізує обробку помилок
using System;

namespace ConsoleApplication2
{
    public class DivideZeroExeption: Exception
    {
        public DivideZeroExeption()
        {
            Console.WriteLine("You divide on zero!!!");
        }
    }
    
    public class MyIndexOutOfRange: Exception
    {
        public MyIndexOutOfRange()
        {
            Console.WriteLine("Index Out Of Range!!!");
        }
    }
}