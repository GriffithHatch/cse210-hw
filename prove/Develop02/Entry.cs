using System.Reflection.Metadata.Ecma335;
using Microsoft.VisualBasic;

class Entry {
    public string prompt;
    public string date;
    public string response;

    public Entry(string prompt, string date, string response)
    {
        this.prompt = prompt;
        this.date = date;
        this.response = response;
    }
    public static string RandomPrompt()
    {
        string[] prompts = {"What happened today?", "What was the best thing that happened today?", "What was the worst thing that happened today?",
        "What was the most interesting thing I saw or heard today?", "What was the most challenging thing I faced today?", "What am I grateful for today?", "What did I learn today?",
        "What was the most fun thing I did today?", "What was the most surprising thing that happened today?", "What did I do today that I am proud of?"};
        Random rnd = new Random();
        int rndnum = rnd.Next(0,9);
        string rndprompt = prompts[rndnum];

        return rndprompt;

    }
    public static string Time(){
        string date = DateTime.Now.ToString();

        return date;

    }
    
    public static string ConvertString(Entry prompt, Entry date, Entry response){
        string journalentry = $"{prompt} {date}\n{response}";

    return journalentry;
    }
    public Entry(string import)
    {
        var stamp = import.Split(",");
        this.prompt = stamp[0];
        this.date = stamp[1];
        this.response = stamp[2];

    }
    public string Export(){
        return $"{prompt}, {date},{response}";
    }
    public string DisplayString()
    {
        return $"{prompt} {date} \n{response}";
    }
}