class ReflectingActivity : Activity{
    ReflectingActivity(int time,DateTime starttime, DateTime stoptime) : base(time,starttime,stoptime){
        
    }
    private static void Prompt(){
        string[] list = {"Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."};
        Random rnd = new Random();
        int randnum = rnd.Next(0,3);
        string guh = list[randnum];
        Console.WriteLine($"{guh}");
    }

    private static void Questions(){
        string[] list = {"Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?","What is your favorite thing about this experience?","What could you learn from this experience that applies to other situations?","What did you learn about yourself through this experience?","How can you keep this experience in mind in the future?"};
        Random rnd = new Random();
        int randnum = rnd.Next(0,3);
        string guh = list[randnum];
        Console.WriteLine($"{guh}");
    }
}