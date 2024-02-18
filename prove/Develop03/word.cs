using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;

class Word
{
    // private bool hidden = false;
    private string word;
    public List<Word> words = new();
    // Every word is its own instance of Word
    
    public void Hideword()
    {
        int count = 0;
        while (count < 3){
            count += 1 ;
            int buh = words.Count;
            Random rnd = new();

            int rndnum = rnd.Next(0,buh-1);

            var guh = words[rndnum];

            // guh.hidden = true;

            var stuff = guh.word;

            guh.word = stuff.Replace(stuff, "______");

            words.RemoveAt(rndnum);
            words.Insert(rndnum, guh);
            Console.WriteLine(guh);
        }


    }

    public List<string> Exportwords(){
        List<string> lstring = new();
        foreach (Word word in words){
            string stuff = word.ToString();
            lstring.Add(stuff);
        }
        // string fullstring = string.Join("",lstring);
        
        return lstring;
    }

    public void Wordify(string script){
        var guh = script.Split(" ");
        foreach (string split in guh)
        {
            Word stuff = new Word
            {
                word = split,
                // hidden = false

            };
            words.Add(stuff);
        }
    }
}