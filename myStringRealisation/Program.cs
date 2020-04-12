using System;


class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World!");
        MyString text = new MyString("kek");
        MyString textTwo = new MyString(" kekw");
        Console.WriteLine(textTwo.Contains(text));
        text = text + textTwo;
        Console.WriteLine(text);
        Console.ReadKey();
    }
}
