using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        BreathingActivity inst = new(0,DateTime.Now,DateTime.Now.AddSeconds(13),DateTime.Now);
        ReflectingActivity inst2 = new(0,DateTime.Now,DateTime.Now.AddSeconds(13),DateTime.Now);
        ListingActivity inst3 = new(0,DateTime.Now,DateTime.Now.AddSeconds(13),DateTime.Now);
        int menu;
        Console.WriteLine("Menu Options:\n 1. Start Breathing Activity\n 2. Start Reflecting Activity\n 3. Start Listing Activity\n 4. Quit");
        Console.WriteLine("Select an option from the menu: ");
        menu = int.Parse(Console.ReadLine());
        int end = 0;
        while(end != 1){
            switch(menu){
                case 1:
                inst.Breathing();

                break;
                case 2:
                inst2.Reflecting();

                break;
                case 3:
                inst3.Listing();

                break;
                case 4:
                end = 1;
                break;
                default:
                Console.WriteLine("Enter a valid option");
                break;
            }
        }

    }
}