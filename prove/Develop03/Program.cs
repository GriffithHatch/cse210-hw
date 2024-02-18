using System;
using System.Diagnostics.CodeAnalysis;
using System.Net.Quic;

class Program
{
    static void Main(string[] args)
    {
        var instatnceofscripture = new Scripture();
        var instanceofreference = new Reference();
        string key = "go";
        Console.WriteLine("This will give you a scripture and reference and slowly take away words for you to practice reciting and memorizing lines");
        Console.WriteLine("Would you like to use your own scripture? type 'yes' or 'no'");
        string addscript = Console.ReadLine();
        if(addscript == "yes"){
            Console.WriteLine("Please put a '!' after the scripture reference before the scripture starts.");
            instatnceofscripture.Import();
            Console.Clear();
        }
        instanceofreference.Spliter();

        instanceofreference.Printfreshscript();


        while(key != ""){
            Console.WriteLine("Press Enter to continue or press anything else to quit");
            var press = Console.ReadKey().Key == ConsoleKey.Enter;
            if(press == true)
            {
                instanceofreference.Printnewscript();
                
            }
            else{
                break;
            }
        }
        


        

        
    }
}