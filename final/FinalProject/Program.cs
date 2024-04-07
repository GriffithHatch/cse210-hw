using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;

class Program
{
    static void Main(string[] args)
    {
        //This area is for initializing and importing weapons, room and stuff from txt files.
        Dungeon instD = new();
        instD.Load();
        Battle instB = new();
        List<Weapon> weapons = new List<Weapon>();
        Weapon.Load(weapons);
        foreach(Weapon weapon in weapons){
            weapon.DisplayWeapon();
        }
        List<Armor> armors = new List<Armor>();
        Armor.Load(armors);
        List<Monsters> monsters = new List<Monsters>();
        Monsters.Load(monsters);
        bool giveup = false;

        Console.WriteLine("You are a mercenary hired by the local lord to investigate strange ruins found in a recently discovered iron mine.");
        Console.WriteLine("The first party exploring the inside of the ruins vanished so expect trouble and prepare for the worst. Keep your wits about you and you should be fine");
        Console.WriteLine("\nKeep your torch burning bright for it will be your hope");

        string mercenarystuff = "guh";
        int mercstart = 0;
        bool valid = false;
        int choice = 0;
        int choice1 = 0;
        while(valid == false){
            Console.WriteLine("How would you like your mercenary to start? There are 3 options");
            Console.WriteLine("1. Leather Armor, Duel Daggers, Speed Potion\n2. Chainmail, Shortsword, Health Potion\n3. Scaled Plate, Longsword, Torch");
            mercstart = int.Parse(Console.ReadLine());
            if (mercstart == 1){
                mercenarystuff = "Leather Armor,Duel Daggers,Speed potion";
                // Console.WriteLine("Opening Inventory, Please remember to equip your armor and a weapon");
                Console.WriteLine("You can open your inventory only outside of battles or actions");
                valid = true;
                choice = 0;
                choice1 = 1;

            }

            else if(mercstart == 2){
                mercenarystuff = "Chainmail,Shortsword,Health potion";
                // Console.WriteLine("Opening Inventory, Please remember to equip your armor and a weapon");
                Console.WriteLine("You can open your inventory only outside of battles or actions");
                valid = true;
                choice = 1;
                choice1 = 2;
            }

            else if(mercstart == 3){
                mercenarystuff = "Scaled Plate,Longsword,Torch";
                // Console.WriteLine("Opening Inventory, Please remember to equip your armor and a weapon");
                Console.WriteLine("You can open your inventory only outside of battles or actions");
                valid = true;
                choice = 2;
                choice1 = 0;
            }
            
            else{
                Console.WriteLine("Please choose one of the 3 options listed");
            }
        }



        var mercstuffsplit = mercenarystuff.Split(",");
        Player mercenary = new(armors[choice],weapons[choice1],mercstuffsplit[2]);
        mercenary.EquipStats();



    Console.WriteLine("You have entered the ruins. They seem to be a series of rooms. Each room seems to shift as you near them the contents are never the same.");
    int menu = 0;
    var go_on = 0;
    while(go_on <= 20){
        mercenary.SanityEffects();
        mercenary.LostSanity();
        int healed = 0;
        if (giveup == true){
            break;
        }
        if (mercenary.CheckDead() == true){
            break;
        }
        Console.WriteLine("1. Enter Room\n 2. Check Inventory\n 3. Check Stats\n 4. Treat Wounds\n 5. Give up");
        menu = int.Parse(Console.ReadLine());
        switch(menu){
            case 1:
            instD.GenerateRoom(mercenary,armors,weapons,monsters);
            go_on += 1;
            break;
            case 2:
            mercenary.Inventory();
            break;
            case 3:
            var stats = mercenary.CheckStats();
            Console.WriteLine(stats);
            break;
            case 4:
            if(healed >= 1){
                Console.WriteLine("You cannot heal again at this time");
            }
            else{mercenary.Heal(5);
            healed += 1;
            }

            break;
            case 5:
            if (go_on <= 5){
                Console.WriteLine("You have not delved too deep into the ruins, You were able to turn around and run");
            if(go_on > 5){
                Console.WriteLine("The bad thing about ruins that constantly shift is its easy to get lost. Your body will probably be found by the next mercenary to come through here");
            }
            }
            giveup = true;
            break;
        }
        

    }
    if (mercenary.CheckDead() == true){
        Console.WriteLine("You have died, its sad but expected. This land is unfair and luck is the deciding factor for everything");
    }
    }
}