using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Assignment bruh = new("Blain Duh", "Addition");
        Console.WriteLine(bruh.Getsummary());
        Mathassignment buh = new("Griffith Hatch","Computer Engineering","7.4","2-5");
        Console.WriteLine(buh.Getsummary());
        Console.WriteLine(buh.GetHomeworkList());
        Writingassignment guh = new("Griffith Hatch", "Computer Engineering","Algorithm Design");
        Console.WriteLine(guh.Getsummary()); //Child Classes can call methods from upwards from the parent class but Parent classes cannot call methods from the child class
        Console.WriteLine(guh.GetWritingInformation());

        
    }
}