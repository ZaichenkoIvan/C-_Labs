using System;

namespace ConsoleApplication1
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            int N, sizeofnamesister, sizeofcube;
            Console.WriteLine("1 - Random values.");
            Console.WriteLine("2 - Values from keyboard.");
            int choise = Convert.ToInt32(Console.ReadLine());
            if (choise == 1)
            {
                Console.WriteLine("Number of cubes : ");
                N = Convert.ToInt32(Console.ReadLine());
                if (N > 100 || N < 0)
                {
                    Console.WriteLine("N must have diapazon (0;100)");
                    Environment.Exit(0);
                }
                Console.WriteLine("Name sister ");
                string s = Console.ReadLine();
                s = s.ToUpper();
                sizeofnamesister = s.Length;
                if (sizeofnamesister > 100)
                {
                    Console.WriteLine("Size of name sister must have less 100 symbols");
                    Environment.Exit(0);
                }
                char[] name = new char[sizeofnamesister];
                name = s.ToCharArray();
                char[][] arrayCube = new char[N][];
                bool[] arrayCubeBool = new bool[N];
                for (int i = 0; i < N; i++)
                {
                    Console.WriteLine("Input some cube : ");
                    s = Console.ReadLine();
                    s = s.ToUpper();
                    sizeofcube = s.Length;
                    if (sizeofcube != 6)
                    {
                        Console.WriteLine("Error");
                        Console.ReadKey();
                        return;
                    }

                    arrayCube[i] = s.ToCharArray();
                    arrayCubeBool[i] = true;
                }

                char[,] outCube = new char[sizeofnamesister, 6];
                bool a = false;
                a = Find(arrayCube, name, N, 0, a, arrayCubeBool, outCube);
                Console.WriteLine("Possibility of creating names is - " + a);
                if (a)
                {
                    Console.WriteLine("Cubes are needed for this : ");
                    for (int i = 0; i < sizeofnamesister; i++)
                    {
                        Console.WriteLine("");
                        for (int j = 0; j < 6; j++)
                            Console.Write(outCube[i, j]);
                    }
                }

                Console.ReadKey();
            }

            else if (choise == 2)
            {
                Random Rnd = new Random();
                N = Rnd.Next(4,100);
                sizeofnamesister = Rnd.Next(4, 100);
                Console.WriteLine("Number of cubes is  "+ N);
                string symb = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string s = "";
                for (int i = 0; i < sizeofnamesister; i++)
                    s += symb[Rnd.Next(0, symb.Length)];
                Console.WriteLine("Name sister is "+ s);
                char[] name = new char[sizeofnamesister];
                name = s.ToCharArray();
                char[][] arrayCube = new char[N][];
                bool[] arrayCubeBool = new bool[N];
                for (int i = 0; i < N; i++)
                {
                    s = "";
                    for (int j = 0; j < 6; j++)
                        s += symb[Rnd.Next(0, symb.Length)];
                    arrayCube[i] = s.ToCharArray();
                    arrayCubeBool[i] = true;
                }
                char[,] outCube = new char[sizeofnamesister, 6];
                bool a = false;
                a = Find(arrayCube, name, N, 0, a, arrayCubeBool, outCube);
                Console.WriteLine("Possibility of creating names is - " + a);
                if (a)
                {
                    Console.WriteLine("Cubes are needed for this : ");
                    for (int i = 0; i < sizeofnamesister; i++)
                    {
                        Console.WriteLine("");
                        for (int j = 0; j < 6; j++)
                            Console.Write(outCube[i, j]);
                    }
                }

                Console.ReadKey();

            }
            else
            {
                Console.WriteLine("Invalid data!");
            }
        }

        public static bool Find(char[][] arrayCube, char[] name, int N, int j, bool a, bool[] arrayCubeBool, char[,] outCube )
        {
            if (j == name.Length) {
                a = true;
                return a;
                    }
            for(int k = 0; k<arrayCube.Length; k++)
            {
                for(int i = 0; i<arrayCube[k].Length; i++)
                {
                    if (arrayCube[k][i] == name[j] && arrayCubeBool[k] )
                    {
                        for (int l = 0; l < arrayCube[k].Length; l++)
                            outCube[j, l] = arrayCube[k][l];
                        arrayCubeBool[k] = false;
                        a = Find(arrayCube, name, N, j + 1, a, arrayCubeBool, outCube);
                        if (a)
                            return a;
                        arrayCubeBool[k] = true;
                    }
                }
            }
            return a;
        }
    }
}