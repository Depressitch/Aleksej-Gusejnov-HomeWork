using System;

public class Program
{
    public static void Main()
    {
        switch (AddCmd.ChoiсeMenu("Choose GDC finding type:", "Euclid's algorithm", "Binary algorithm"))
        {
            case 1:
                Console.Clear();
                Console.Write("Input number a: ");
                int a1 = Parse.IntValue("number");
                Console.Write("Input number b: ");
                int b1 = Parse.IntValue("number");
                Console.WriteLine($"GDC of {a1} and {b1} is {AddCmd.EuclidGCD(a1, b1)} ");
                break;
            case 2:
                Console.Clear();
                Console.Write("Input number a: ");
                int a2 = Parse.IntValue("number");
                Console.Write("Input number b: ");
                int b2 = Parse.IntValue("number");
                Console.WriteLine($"GDC of {a2} and {b2} is {AddCmd.BinaryGCD(a2, b2)} ");
                break;
            default:
                break;
        }
        AddCmd.Repeat('r');
    }
}
