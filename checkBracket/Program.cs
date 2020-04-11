using System;
using System.Linq;
using System.Collections.Generic;

class Program
{
    public static void Main()
    {
        Console.WriteLine("Input a line:");
        string input = Console.ReadLine();
        Console.WriteLine("Brackets in this line are " +
            (CheckIfValidBrackets(input) ? "" : "not ") +
            "balanced.");//CheckIfValidBrackets(input)
        Console.ReadKey();
    }

    public static bool CheckIfValidBrackets(string text) //более правильная реализация, используя стэк (уже позже подсмотрел, каюсь)
    {
        Stack<char> tested = new Stack<char>();
        for (int i = 0; i < text.Length; i++)
        {
            if (text[i] == '(' || text[i] == '{') //если элемент - открывающая скобка, то добавляем его в стэк
                tested.Push(text[i]);
            else if (text[i] == ')' || text[i] == '}') //если это закрывающая скобка
            {
                if (tested.Count == 0) //если стэк пустой, то есть открытых скобок внутри нет
                    return false;
                else
                {
                    char popped = tested.Pop(); //достаём последний элемент стэка и запоминаем его значение
                    if ((popped == '(' && text[i] == '}') || (popped == '{' && text[i] == '}')) //проверяем является ли текующий элемент строки с тем, который достали
                        return false;
                }
            }
        }
        return tested.Count == 1 ? false : true; //проверяется была ли введена всего одна скобка
    }
}