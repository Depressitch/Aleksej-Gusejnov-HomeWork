using System;
using System.Collections.Generic;
using System.Text;

public static class AddCmd
{
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
    public static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }
    public static bool IsPrime(int num)  //функция для определения является ли число простым
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
    public static int BinaryGCD(int a, int b)
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
                return BinaryGCD(a >> 1, b >> 1) << 1; 
            else //в противном случае чётно только a
                return BinaryGCD(a >> 1, b);
        }
        if (b % 2 == 0) //в таком случае чётно только b
            return BinaryGCD(a, b >> 1);
        if (a > b) //оба нечётны, проверяем какое число больше
            return BinaryGCD((a - b) >> 1, b);
        return BinaryGCD((b - a) >> 1, a);
    }
    public static byte ChoiсeMenu(string title, params string[] options)
    {
        Console.WriteLine($"{title}\n");
        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }
        Console.WriteLine("Anything else - exit");
        Console.Write("\nYour choise: ");
        byte result = Parse.ByteValue("option");
        return result;
    }
}