class ListingActivity : Activity {
    public ListingActivity(int time,DateTime starttime, DateTime stoptime, DateTime currenttime) : base(time,starttime,stoptime,currenttime){

    }
        private static void Prompt(){
        string[] list = {"Who are people that you appreciate?","What are personal strengths of yours?","Who are people that you have helped this week?","When have you felt the Holy Ghost this month?","Who are some of your personal heroes?"};
        Random rnd = new Random();
        int randnum = rnd.Next(0,3);
        string prompt = list[randnum];
        Console.WriteLine($"---{prompt}---");
    }
    public void Listing(){
        int count = 0;
        Console.WriteLine("Welcome To the Listing Activity\n");
        Console.WriteLine("\nThis activity will help you reflect on some good things in life by having you list them off aided by a prompt.\n");
        GetTime();
        Console.Clear();
        Console.WriteLine("Think on the following prompt for a few seconds then after the spinner begin listing what comes to mind");
        Prompt();
        BeginIn();
        SetTimer();
        while(currenttime < stoptime){
            string guh;
            count += 1;
            guh = Console.ReadLine();
            currenttime = DateTime.Now;
        }
        Console.WriteLine($"\nYou listed {count} items");
        WellDone("Listing Activity");
        Console.Clear();

    }
}