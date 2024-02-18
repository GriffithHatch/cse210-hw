using System.Reflection.Metadata;
using System.Runtime.InteropServices;

class Reference{
    private string script ="";
     string refrences = "";

    public void Spliter()
    {
        var instant1 = new Scripture();
        var instant2 = new Word();
        var stuff = instant1.Exportscript();
        this.refrences = stuff[0];
        this.script = stuff[1];
        instant2.Wordify(script);
    }

    public void Printfreshscript()
    {
        Console.WriteLine($"{refrences} {script}");
    }

    public void Printnewscript()
    {
        var instant = new Word();
        List<string> newlist = instant.Exportwords();
        var stuff = string.Join("-",newlist);
        Console.WriteLine($"{refrences} {stuff}");
    }



}