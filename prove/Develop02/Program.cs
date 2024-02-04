using System;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static public Journal journal;


    static void Main(string[] args)
    
    {
        journal = new Journal();
        bool keepGoing = true;
        while(keepGoing){
            Console.WriteLine("Journal Menu Options:");
            Console.WriteLine("Write");
            Console.WriteLine("Display");
            Console.WriteLine("Load");
            Console.WriteLine("Save");
            Console.WriteLine("Quit");

            int input = int.Parse(Console.ReadLine());
            switch(input)
            {
                case 1:

                journal.AddEntry();
                // Console.Clear();

                break;

                case 2:
                journal.DisplayEntry();

                break;

                case 3:
                var load = SaveWrite.ReadFromFile();
                journal = new Journal(load);
                break;

                case 4:
                var save = journal.Export();
                SaveWrite.WriteFile(save);
                //TURNS OUT ITS BEEN SAVING TO THE BIN FOLDER IN DEVELOP02
                //I SPENT HOURS WONDERING IF THE CODE WAS WORKING
                //I didn't get any error but I could not find my .txt files
                //so much time wasted
                //but at least it works

                
                break;

                case 5:
                keepGoing = false;

                break;

                default:
                keepGoing = false;

                break;

            }
        }

        
        //Use Console.Clear(); to make it look much cleaner.
    }
    // static string[] ReadFromFile(){
    //     Console.Write("Enter filename: ");
    //     var filename = Console.ReadLine();
    //     return File.ReadAllLines(filename);
        
    // }
    // static void WriteFile(string[] entries){
    //     Console.WriteLine("Enter Filename: ");

    //     var filename = Console.ReadLine();
    //     File.WriteAllLines(filename, entries);


    // }
}