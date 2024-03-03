using System;
using System.Collections;

class Program
{
    static void Main(string[] args)
    {
        int menu;
        Console.WriteLine("Menu Options:\n 1. Start Breathing Activity\n 2. Start Reflecting Activity\n 3. Start Listing Activity\n 4. Quit");
        Console.WriteLine("Select an option from the menu: ");
        menu = int.Parse(Console.ReadLine());
        switch(menu){
            case 1:
            Activity.Spinner();
            break;
            case 2:

            break;
            case 3:

            break;
            case 4:
            break;
            default:
            Console.WriteLine("Enter a valid option");
            break;
        }

    }
}