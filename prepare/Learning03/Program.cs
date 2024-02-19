using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction guh = new();
        Console.WriteLine(guh.FractionString());
        Console.WriteLine(guh.Fractiondecimal());

        Fraction meh = new(5);
        Console.WriteLine(meh.FractionString());
        Console.WriteLine(meh.Fractiondecimal());

        Fraction buh = new(1,3);
        Console.WriteLine(buh.FractionString());
        Console.WriteLine(buh.Fractiondecimal());

        Fraction duh = new(5,2);
        Console.WriteLine(duh.FractionString());
        Console.WriteLine(duh.Fractiondecimal());

    }
}