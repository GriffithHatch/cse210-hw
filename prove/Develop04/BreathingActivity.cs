using System.Data;

class BreathingActivity : Activity{
    public BreathingActivity(int time,DateTime starttime, DateTime stoptime, DateTime currenttime) : base(time,starttime,stoptime,currenttime){
    }
    public void Breath(){
        List<string> breathin = new List<string>{
            "4",
            "3",
            "2",
            "1"
        };
        List<string> breathout = new List<string>{
            "6","5","4","3","2","1"
        };
        Console.Write("Breath in...");
        foreach(string s in breathin){
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

        Console.WriteLine();

        Console.Write("Breath out...");
        foreach(string s in breathout){
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }

        Console.WriteLine();
    }
    public void Breathing(){
        Console.WriteLine("This activity will help you relax your breathing with simple breath in and breath out prompts. Focus on your breathing.\n");
        GetTime();
        BeginIn();
        Console.Clear();
        SetTimer();
        while(currenttime < stoptime){
            Breath();
            currenttime = DateTime.Now;
        }
        Console.Clear();
        WellDone("Breathing Activity");
        Console.Clear();
    }
}