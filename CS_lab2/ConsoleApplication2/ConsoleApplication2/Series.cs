//Клас реалізує колекцію обєктів та події
using System;
using System.Collections;
using System.Collections.Generic;
namespace ConsoleApplication2
{
    public class Series
    {
        public delegate void MethodContainer1(); 
        public delegate void MethodContainer2(); 
        public delegate void MethodContainer3();
        
        public event MethodContainer1 eventAdd;
        public event MethodContainer2 eventRemove;
        public event MethodContainer3 eventChangeData;
        
        List<Solution> someSeries = new List<Solution>();

        public Series()
        {
        }

        public Series(Solution equation)
        {
            someSeries.Add(equation);
            eventAdd();
        }

        public void AddSeries(Solution equation)
        {
            someSeries.Add(equation);
            eventAdd();
        }

        public void Remove (int index) 
        {
            if (index < 0 || index >= someSeries.Count) 
                throw new MyIndexOutOfRange();
            someSeries.RemoveAt(index);
            eventRemove();
        }

        public void Print()
        {
            foreach (Solution element in someSeries)
            {
                element.ToString();
                Console.WriteLine();
            }
        }

        public List<Solution> DeepCopy()
        {
            List<Solution> someSeries2 = new List<Solution>();
            foreach (Solution element in someSeries)
            {
                if (element is Linear)
                {
                    Linear equation = new Linear(element.A, element.B);
                    someSeries2.Add(equation);
                }
                else if (element is Square)
                {
                    Square equation = new Square(element.A, element.B, element.C);
                    someSeries2.Add(equation);
                }
            }

            return someSeries2;
        }

        public void ChangeData(int index, double a, double b)
        {
            if (index < 0 || index >= someSeries.Count) 
                throw new MyIndexOutOfRange();
            int i = 0;
            foreach (Solution element in someSeries)
            {
                if( i == index){
                    if (element is Linear)
                    {
                        element.A = a;
                        element.B = b;
                        element.Calculation(element.A, element.B);
                        eventChangeData();
                    }
                    else 
                        Console.WriteLine("Invalid index ");
                    break;
                }

                i++;
            }

        }
        
        public void ChangeData(int index, double a, double b, double c)
        {
            if (index < 0 || index >= someSeries.Count) 
                throw new MyIndexOutOfRange();
            int i = 0;
            foreach (Solution element in someSeries)
            {
                if( i == index){
                    if (element is Square)
                    {
                        element.A = a;
                        element.B = b;
                        element.C = c;
                        element.Calculation(element.A, element.B, element.C);
                        eventChangeData();
                    }
                    else 
                        Console.WriteLine("Invalid index for change data. Data not change");
                    break;
                }

                i++;
            }

            
        }
}
    class MessageAdd
    {
        public void Message()
        {
            Console.WriteLine("Added new element in collection"); 
        }                                                        
    }
    class MessageRemove
    {
        public void Message()
        {
            Console.WriteLine("Removed element in collection"); 
        }                                                        
    }
    class MessageChangeData
    {
        public void Message()
        {
            Console.WriteLine("Changed data element in collection"); 
        }                                                        
    }
}