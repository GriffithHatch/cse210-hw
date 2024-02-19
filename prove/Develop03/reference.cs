using System.Reflection.Metadata;
using System.Runtime.InteropServices;

class Reference{
    private string script ="";
     string refrences = "";

    public void Spliter()
    {
        var instant1 = new Scripture();
        var instant2 = new Word("guh");
        var stuff = instant1.Exportscript();
        refrences = stuff[0];
        script = stuff[1];
        instant2.Wordify(script);
    }

    public void Printfreshscript()
    {
        Console.WriteLine($"{refrences} {script}");
    }

    public void Printnewscript()
    {
        var instant = new Word("guh");
        string newlist = instant.Exportwords();
        Console.WriteLine($"{refrences} {newlist}");
    }



}