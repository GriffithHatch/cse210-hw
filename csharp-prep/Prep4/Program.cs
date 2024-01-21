using System;
using System.ComponentModel;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Prep4 World!");
        int i;
        string s;
        char c;
        float f;
        double d;
        byte b;
        List<int> myInts = new List<int>();
        var otherInts = new List<int>();

        myInts.Add(10);
        myInts.Add(3);
        myInts.Add(45);
        foreach(var n in myInts){
            Console.WriteLine ($"n = {n}");
        }
        
        
    }
}