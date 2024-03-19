using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        Goal guh = new(1);
        int end = 0;
        List<Goal> goals = new List<Goal>();
        while(end != 1){
            Console.WriteLine("What would you like to do today?\n 1. Create Goal\n 2. List All Goals\n 3. Save Goals\n 4. Load Goals\n 5. Record Goals\n 6. Quit Goal Program");
            int menu = int.Parse(Console.ReadLine());
            switch(menu){
                case 1:
                Console.WriteLine("1. Simple Goal\n2. Eternal Goal\n3. Checklist Goal");
                int menu2 = int.Parse(Console.ReadLine());
                switch(menu2){
                    case 1:
                    Simple goal = new();
                    goals.Add(goal);
                    break;
                    case 2:
                    Eternal goal2 = new();
                    goals.Add(goal2);
                    break;
                    case 3:
                    Checklist goal3 = new();
                    goals.Add(goal3);
                    break;
                }
                break;
                case 2:
                    Console.WriteLine($"Your current point total is: {guh.GetPoints()}");
                    Console.WriteLine($"You have completed {guh.GetCompletions()} goals");
                    foreach(Goal line in goals){
                        line.Display();
                    }
                break;
                case 3:
                string filename;
                Console.WriteLine("What filename would you like to save your goals to?");
                filename = Console.ReadLine();
                guh.Save(filename, goals);
                break;
                case 4:
                Console.WriteLine("What file would you like to load?");
                filename = Console.ReadLine();
                guh.Load(filename, goals);
                break;
                case 5:

                Console.Clear();
                int count = 0;
                foreach(Goal line in goals){
                    count += 1;
                    Console.Write($"{count}. "); line.Display();
                }

                Console.WriteLine("Choose a goal to record");
                int choice = int.Parse(Console.ReadLine());
                var inst = goals[choice - 1];
                inst.RecordGoal(); //inst already knows all the info for the entry. You do not need to add anything.

                break;

                case 6:
                end = 1;
                break;
                default:
                Console.Clear();
                Console.WriteLine("Please Enter a valid input");
                break;
            }

    }
    
}
}