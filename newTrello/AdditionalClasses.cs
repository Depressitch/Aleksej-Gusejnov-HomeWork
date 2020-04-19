using System;
using System.Collections.Generic;
using System.Text;

namespace TrelloClone
{
    public static class AddCmd
    {
        #region console
        public static void Repeat(char repeatKey)
        {
            Console.WriteLine("===============================\n" +
                        $"Press \"{repeatKey}\" to repeat the program.");
            if (Console.ReadKey().KeyChar == repeatKey) //если нажата repeatKey, то программа перезапустится, предварительно очистив консоль
            {
                Console.Clear();
                Program.Main();
            }
        }
        public static int ChoiсeMenu(string title, params string[] options)
        {
            Console.WriteLine($"{title}\n");
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {options[i]}");
            }
            Console.WriteLine("Anything else - exit");
            Console.Write("\nYour choise: ");
            int result = Parse.ByteValue("option");
            return result;
        }
        #endregion
        #region numbers
        public static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
        public static bool IsPrime(this int num)  //функция для определения является ли число простым
        {
            //если остаток от деления на 2 не равен 0, то начинается проверка на простоту
            if (num % 2 != 0 && num >= 2)
            {
                /*
                вводим переменную для условия продолжения цикла, чтобы не высчитывать корень в каждой итеррации 
                наименьший делитель числа не превосходит корень этого числа
                */
                int sqrtNum = (int)Math.Sqrt(num);
                for (int j = 3; j <= sqrtNum; j += 2)
                    if (num % j == 0) //если делится каким-либо числом нацело, то false
                        return false;
                return true;
            }
            //так как из-за первого условия мы можем попасть на двойку, то проверяем чтобы не допустить ошибку
            if (num == 2)
                return true;
            return false;
        }
        public static int EuclidGCD(int a, int b)
        {
            return b == 0 ? Math.Abs(a) : EuclidGCD(b, a % b);
        }
        public static int BinaryGDC(int a, int b)
        {
            if (a == b)
                return a;
            if (a == 0)
                return b;
            if (b == 0)
                return a;
            if (a == 1 || b == 1)
                return 1;
            if (a % 2 == 0) //если первое число чётное, то
            {
                if (b % 2 == 0) //если оба чётные, то
                    return BinaryGDC(a >> 1, b >> 1) << 1;
                else //в противном случае чётно только a
                    return BinaryGDC(a >> 1, b);
            }
            if (b % 2 == 0) //в таком случае чётно только b
                return BinaryGDC(a, b >> 1);
            if (a > b) //оба нечётны, проверяем какое число больше
                return BinaryGDC((a - b) >> 1, b);
            return BinaryGDC((b - a) >> 1, a);
        }
        public static int Randomize()
        {
            Random rnd = new Random(Environment.TickCount);
            return rnd.Next();
        }
        public static int Randomize(int startRegion, int endRegion)
        {
            Random rnd = new Random(Environment.TickCount);
            return rnd.Next(startRegion, endRegion);
        }
        #endregion
    }
}