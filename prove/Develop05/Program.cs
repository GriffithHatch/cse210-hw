using System;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

class Program
{
    static void Main(string[] args)
    {
        int end = 0;
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
                    Goal.goals.Add(goal);
                    break;
                    case 2:
                    Eternal goal2 = new();
                    Goal.goals.Add(goal2);
                    break;
                    case 3:
                    Checklist goal3 = new();
                    Goal.goals.Add(goal3);
                    break;
                }
                break;
                case 2:
                    foreach(Goal line in Goal.goals){
                        line.Display();
                    }
                break;
                case 3:
                break;
                case 4:
                break;
                case 5:

                Console.Clear();
                int count = 0;
                foreach(Goal line in Goal.goals){
                    count += 1;
                    Console.Write($"{count}. "); line.Display();
                }

                Console.WriteLine("Choose a goal to record");
                int choice = int.Parse(Console.ReadLine());
                var inst = Goal.goals[choice - 1];
                inst.RecordGoal(choice);

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
public static void Save(){

}
public static void Load(){
    
}
}