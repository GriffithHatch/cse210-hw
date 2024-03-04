class Activity{
    protected int time;
    protected DateTime starttime;
    protected DateTime stoptime;
    protected DateTime currenttime;
    public Activity(int time,DateTime starttime, DateTime stoptime,DateTime currenttime) {
    }

    protected int GetTime(){
        Console.WriteLine("How long, in seconds, would you like for your session? ");
        time = int.Parse(Console.ReadLine());
        return time;
    }
    protected void GetReady(){
        Console.WriteLine("Get Ready");
        Spinner();
    }

    public static void Spinner(){
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
            "\\"


        };

        foreach(string s in animation){
            Console.Write(s);
            Thread.Sleep(750);
            Console.Write("\b \b");
        }
    }

    protected void SetTimer(){
        starttime = DateTime.Now;
        stoptime = starttime.AddSeconds(time);
    }
    protected void WellDone(string guh){
        Console.WriteLine("Well Done!\n");
        Console.WriteLine($"You have comepleted another {time} seconds of {guh}");
        Spinner();
    }
    protected void BeginIn(){
        List<string> guh = new List<string>{
            "5","4","3","2","1"
        };
        Console.Write("You may begin in...");
        foreach(string s in guh){
            Console.Write(s);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}