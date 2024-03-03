class Activity{
    protected int time;
    protected DateTime starttime;
    protected DateTime stoptime;
    public Activity(int time,DateTime starttime, DateTime stoptime) {
    }

    protected int GetTime(){
        Console.WriteLine("How long, in seconds, would you like for your session? ");
        time = int.Parse(Console.ReadLine());
        return time;
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
            "\\"
        };

        foreach(string s in animation){
            Console.WriteLine(s);
            Thread.Sleep(1000);
            Console.WriteLine("\b \b");
        }
    }

    protected void SetTimer(){
        starttime = DateTime.Now;
        stoptime = starttime.AddSeconds(time);
    }
}