using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fibanachi
{
    public class Fibonachi: Base
    {
        public static List<Fibonachi> fibArr = new List<Fibonachi>();
        public Fibonachi():base() //наследуется от базового конструктора Random
        { }

        public Fibonachi(uint fib_znach):base(fib_znach) //конструктор для конвертации
        { }

        public Fibonachi(string st_znach):base(st_znach) //конструктор для де конвертации
        { }

        public static Fibonachi ConvertToFIB(uint znachDEC)
        {
            Fibonachi fib = new Fibonachi(znachDEC);
            IList<uint> fibonacchiNumbers = new List<uint>();
            uint rash = 0;
            uint FIBoutDEC = 0;

            if (znachDEC < 2)
            {
                fib.znach = znachDEC;
                fib.st_znach = znachDEC.ToString();
            }
            else
            {
                fibonacchiNumbers.Add(1);
                fibonacchiNumbers.Add(2);

                for (int i = 2; ; i++)
                {
                    Console.WriteLine($"znach: {znachDEC} - rash: {znachDEC}");
                    rash = fibonacchiNumbers[i - 1] + fibonacchiNumbers[i - 2]; //расчет по формуле
                    if (rash > znachDEC) //если число больше чем входное, то выходим из цикла
                    {
                        break;
                    }
                    else
                    {
                        FIBoutDEC = rash;
                        fibonacchiNumbers.Add(rash);
                    }
                }

                string s = "";
                uint temp = znachDEC;

                foreach (uint item in fibonacchiNumbers.Reverse()) // foreach (int item in fibonacchiNumbers.Reverse())
                {
                    if (item <= temp)
                    {
                        s = s + "1";
                        temp -= item;
                        Console.WriteLine($"{item} - 1");
                    }
                    else
                    {
                        s = s + "0";
                        Console.WriteLine($"{item} - 0");
                    }
                }

                Console.WriteLine(s);
                fib.st_znach = s;
                fib.znach = znachDEC;
            }

            return fib;
        }

        public static Fibonachi ConvertToDEC(string znachFIB, out bool correctFIB)
        {
            Fibonachi fib = new Fibonachi(znachFIB);

            IList<byte> fibByte = new List<byte>();
            IList<uint> fibZnach = new List<uint>();
            char[] charArr = znachFIB.ToCharArray();
            bool ifFIB = false;

            foreach (char ch in charArr) //заносим в список массив байтов(Фибоначчи)
            {
                fibByte.Add(Convert.ToByte(ch));
                Console.WriteLine(ch);
            }

            int i = -1; //счетчик
            uint rash = 0; //расчетное число
            foreach (byte item in fibByte.Reverse())//Сортируем в обратной последовательности
            {
                //if i<2 то не выполняем функцию
                //иначе выполняем функцию F3 = F2 + F1, F4 = F3 + F2, F5 = F4 + F3 и т.д.
                i++;
                //нахождение элементов последовательности
                if (i < 2)
                {
                    if (i == 0)
                        fibZnach.Add(1);
                    else if (i == 1)
                        fibZnach.Add(2);
                }
                else
                {
                    uint fibF = fibZnach[i - 1] + fibZnach[i - 2];
                    fibZnach.Add(fibF);
                }

                //расчет элементов последовательности,
                //если 1, то это элемент последовательности
                //иначе 0, то это не элемент последовательности
                if (item == 49)//1
                {
                    rash = rash + fibZnach[i];
                    Console.WriteLine($"i:{i} - 1");
                    ifFIB = true;
                }
                else if (item == 48)//0
                {
                    Console.WriteLine($"i:{i} - 0");
                    ifFIB = true;
                }

                else
                {
                    ifFIB = false;
                    correctFIB = ifFIB;
                    break;
                }
            }
            correctFIB = ifFIB;
            fib.znach = rash;

            return fib;
        }

#region old metods
        public string ConvertToFib_byte(uint znach) //ConvertToFib_byte(int znach)
        {
            IList<uint> fibonacchiNumbers = new List<uint>();
            uint rash = 0;
            uint FIBoutDEC = 0;

            if (znach < 2)
            {
                return znach.ToString();
            }
            else
            {
                fibonacchiNumbers.Add(1);
                fibonacchiNumbers.Add(2);

                for (int i = 2; ; i++)
                {
                    Console.WriteLine($"znach: {znach} - rash: {rash}");
                    rash = fibonacchiNumbers[i - 1] + fibonacchiNumbers[i - 2]; //расчет по формуле
                    if (rash > znach) //если число больше чем входное, то выходим из цикла
                    {
                        break;
                    }
                    else
                    {
                        FIBoutDEC = rash;
                        fibonacchiNumbers.Add(rash);
                    }
                }
            }
            
            string s = "";
            uint temp = znach; //int temp = znach;

            foreach (uint item in fibonacchiNumbers.Reverse()) // foreach (int item in fibonacchiNumbers.Reverse())
            {
                if (item <= temp)
                {
                    s = s + "1";
                    temp -= item;
                    Console.WriteLine($"{item} - 1");
                }
                else
                {
                    s = s + "0";
                    Console.WriteLine($"{item} - 0");
                }
            }
            return s;
        }

        public string ConvertToDEC_byte(string znach, out bool correctFIB)
        {
            IList<byte> fibByte = new List<byte>();
            IList<int> fibZnach = new List<int>();
            char[] charArr = znach.ToCharArray();
            bool ifFIB = false;

            foreach (char ch in charArr) //заносим в список массив байтов(Фибоначчи)
            {
                fibByte.Add(Convert.ToByte(ch));
                Console.WriteLine(ch);
            }

            int i = -1; //счетчик
            int rash = 0; //расчетное число
            foreach (byte item in fibByte.Reverse())//Сортируем в обратной последовательности
            {
                //if i<2 то не выполняем функцию
                //иначе выполняем функцию F3 = F2 + F1, F4 = F3 + F2, F5 = F4 + F3 и т.д.
                i++;
                //нахождение элементов последовательности
                if(i<2)
                {
                    if (i == 0)
                        fibZnach.Add(1);
                    else if (i == 1)
                        fibZnach.Add(2);
                }
                else
                {
                    int fibF = fibZnach[i - 1] + fibZnach[i - 2];
                    fibZnach.Add(fibF);
                }

                //расчет элементов последовательности,
                //если 1, то это элемент последовательности
                //иначе 0, то это не элемент последовательности
                if (item == 49)//1
                {
                    rash = rash + fibZnach[i];
                    Console.WriteLine($"i:{i} - 1");
                    ifFIB = true;
                }
                else if (item == 48)//0
                {
                    Console.WriteLine($"i:{i} - 0");
                    ifFIB = true;
                }
                    
                else
                {
                    ifFIB = false;
                    correctFIB = ifFIB;
                    break;
                }
                    

            }

            correctFIB = ifFIB;
            return rash.ToString(); 
        }

#endregion
    }
    
    class FibonachiSortUp : IComparer<Fibonachi> //сортировка вверх
    {
        public int Compare(Fibonachi t1, Fibonachi t2)
        {
            if(t1.Znach > t2.Znach)
            {
                return 1;
            }
            else if (t1.Znach < t2.Znach)
            {
                return -1;
            }
            return 0;
        }
    }

    class FibonachiSortDown : IComparer<Fibonachi> //сортировка вниз
    {
        public int Compare(Fibonachi t1, Fibonachi t2)
        {
            if (t1.Znach < t2.Znach)
            {
                return 1;
            }
            else if (t1.Znach > t2.Znach)
            {
                return -1;
            }
            return 0;
        }
    }


}

