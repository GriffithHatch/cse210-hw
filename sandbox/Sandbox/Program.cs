using System;

class Program
{
    static void Main(string[] args)
    {
        var time = 10;
        int Timer(){
        var starttime = DateTime.Now;
        var stoptime = starttime.AddSeconds(time);
        while (starttime != stoptime){
            return 0;
        }
        return 1;
    }
    int count = Timer();
    int guh = 0;
    while(count != 1){
        guh += 1;
        Thread.Sleep(1000);
        Console.WriteLine(guh);
        }
    }
}