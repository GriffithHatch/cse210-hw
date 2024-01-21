using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Prep5 World!");
        int number = PromptUserNumber();
        string username = PromptUserName();
        var favnumber = SquareNumber(number);
        DisplayResult(username,favnumber);

    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Jungle!");
    }

    static string PromptUserName()
    {
        Console.WriteLine("Enter Username");
        string username = Console.ReadLine();
        return username;
    }

    static int PromptUserNumber()
    {
        Console.WriteLine("Enter your favorite number");
        int favnumber = int.Parse(Console.ReadLine());
        return favnumber;
    }

    static int SquareNumber(int number)
    {
        int num = number * number;
        return num;
    }

    static void DisplayResult(string username, int sqnumber)
    {
        Console.WriteLine($"{username}, {sqnumber}");
    }

}