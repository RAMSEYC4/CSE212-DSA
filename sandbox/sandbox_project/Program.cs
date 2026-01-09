using System;

public class Program
{
    static void Main(string[] args)
    {
        // This project is here for you to use as a "Sandbox" to play around
        // with any code or ideas you have that do not directly apply to
        // one of your projects.

        // Console.WriteLine("Hello Sandbox World!");
        var numbers = new int[3];
        numbers[0] = 1;
        numbers[1] = 2;
        numbers[2] = 3;
        foreach (var n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}