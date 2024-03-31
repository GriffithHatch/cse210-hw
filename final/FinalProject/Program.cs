using System;
using System.ComponentModel.DataAnnotations;

class Program
{
    static void Main(string[] args)
    {
        int mercstart = 0;
        bool valid = false;
        while(valid == false)
        Console.WriteLine("How would you like your mercenary to start? There are 3 options");
        Console.WriteLine("1. Leather Armor, Duel daggers, Sturdy bow, Health potion.\n 2. Chainmail, Short sword, Weak bow, Swiftness potion, Health potion\n 3.Scaled Plate, Longsword, Health potion");
        mercstart = int.Parse(Console.ReadLine());
        if (mercstart == 1){

            valid = true;
        }

        else if(mercstart == 2){
            valid = true;
        }

        else if(mercstart == 3){
            valid = true;
        }
        
        else{
            Console.WriteLine("Please choose one of the 3 options listed");
        }
    }
}