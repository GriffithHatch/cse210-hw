using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

class Journal{
    public List<Entry> entries;
    public Journal()
    {
        entries = new List<Entry>();

    }
    public Journal(string[] importentry)
    {
        entries = new List<Entry>();
        foreach (var c in importentry)
        {
            var list = new Entry(c);
            entries.Add(list);
        }
    }
    public void AddEntry(){

        var prompt = Entry.RandomPrompt();

        var date = Entry.Time();

        Console.WriteLine(prompt);

        var response = Console.ReadLine();

        var entry = new Entry(prompt, date, response);

        entries.Add(entry);
    }

    public void DisplayEntry(){
        foreach (var entry in entries){

            Console.WriteLine(entry.DisplayString());
        }

    }
    public string[] Export()
    {
        var exportline = new List<string>();
        foreach (var entry in entries)
        {
            exportline.Add(entry.Export());
        }
        return exportline.ToArray();
    }
}
