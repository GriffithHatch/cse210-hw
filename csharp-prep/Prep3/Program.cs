using System;
using System.Collections.Concurrent;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Prep3 World!");

        // int count= 0;
        // while(count < 5)
        // {
            // System.Console.WriteLine($"count =  {count++}");

           // count += 1;
        // }
        // int moreCount = 0;
        // do {
            // System.Console.WriteLine($"count = {moreCount++}");
        // }while(moreCount < 5);

        // for(var i=0; i<5; ++i) {
            // System.Console.WriteLine($"i = {i}");
        // }
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 11);

        Console.WriteLine("Guess a number: ");
        int guess = 0;
        bool correct = false;

        while(correct == false){
            guess = int.Parse(Console.ReadLine());

            if (guess > number)
            {
                Console.WriteLine("Too High");
            }
            else if (guess < number)
            {
                Console.WriteLine("Too Low");
            }
            else if (guess == number)
            {
                Console.WriteLine("Just Right");
                correct = true;
            }
            else{
                Console.WriteLine("ERROR");
            }
            
        }





    }
}