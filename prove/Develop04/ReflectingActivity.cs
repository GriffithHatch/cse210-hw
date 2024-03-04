class ReflectingActivity : Activity{
    public ReflectingActivity(int time,DateTime starttime, DateTime stoptime, DateTime currenttime) : base(time,starttime,stoptime,currenttime){
        
    }
    private static void Prompt(){
        string[] list = {"Think of a time when you stood up for someone else.", "Think of a time when you did something really difficult.", "Think of a time when you helped someone in need.", "Think of a time when you did something truly selfless."};
        Random rnd = new Random();
        int randnum = rnd.Next(0,3);
        string prompt = list[randnum];
        Console.WriteLine($"---{prompt}---");
    }

    private static void Questions(){
        string[] list = {"Why was this experience meaningful to you?", "Have you ever done anything like this before?", "How did you get started?", "How did you feel when it was complete?", "What made this time different than other times when you were not as successful?","What is your favorite thing about this experience?","What could you learn from this experience that applies to other situations?","What did you learn about yourself through this experience?","How can you keep this experience in mind in the future?"};
        Random rnd = new Random();
        int randnum = rnd.Next(0,3);
        string question = list[randnum];
        Console.Write($"{question}");
    }
    private static void LongSpinner(){
        List<string> animation = new List<string>
        {
            "/",
            "|",
            "\\",
            "-",
            "/",
            "|",
            "\\",
            "-",
            "/",
            "|",
            "\\",
            "-",
            "/",
            "|",
            "-"


        };

        foreach(string s in animation){
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public void Reflecting(){
        Console.WriteLine("Welcome to the Reflecting Activity");
        Console.WriteLine("\nThis activity will help you reflect on time in your life you showed strength and resiliance. Recognize the power you have and how you can use it in other aspects of your life.\n");
        GetTime();
        Console.Clear();
        GetReady();
        Console.WriteLine("Consider the Following Prompt:\n");
        Prompt();
        Console.WriteLine("When you have something in mind, press the ENTER key to continue.");
        while (Console.ReadKey().Key != ConsoleKey.Enter) {}
        Console.WriteLine("Think about the following questions and how they relate to this experience\n");
        BeginIn();
        SetTimer();
        while(currenttime < stoptime){
            Questions();
            LongSpinner();
            Console.WriteLine();
            currenttime = DateTime.Now;
        }
        Console.Clear();
        WellDone("Reflecting Activity");
        Console.Clear();


    }
}