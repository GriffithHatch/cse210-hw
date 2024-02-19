using System.Diagnostics;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

class Word
{
    // private bool hidden = false;
    private string word;
    private static List<Word> words = new List<Word>(); // I lost hours because I didn't know that I had to make this static in order
    // for other methods to use the same list.

    
    // Every word is its own instance of Word
    public Word(string meh){
        word = meh;
        // hidden = false;
    }
    
    public void Wordify(string script){
        var guh = script.Split(" ");
        
        foreach (string split in guh)
        {
            words.Add(new Word(split));
        }
    }
    // private void Hideword()
    // {
    //     int counts = 0;
    //     while (counts < 3){
    //         counts += 1 ;
    //         int buh = words.Count;
    //         Console.WriteLine(buh);
    //         Random rnd = new();

    //         int rndnum = rnd.Next(0,buh);

    //         var guh = words[rndnum];

    //         // guh.hidden = true;

    //         var stuff = guh.word;

    //         guh.word = stuff.Replace(stuff, "______"); // This was just to test if my code was even working. it was not

    //         words.RemoveAt(rndnum);
    //         words.Insert(rndnum, guh);
    //         Console.WriteLine(guh);
    //     }
// Today I have learned that I suck at coding so bad
// I used Chat GPT to help me with Hideword()
// I was in pain trying to fix this but it now works. I also understand why it did not work before

    // }
    private void Hideword()
{
    int counts = 0;
    while (counts < 3 && words.Count > 0)
    {
        counts += 1;

        Random rnd = new Random();
        int rndnum = rnd.Next(0, words.Count);

        var wordToHide = words[rndnum];

        // Replace part of the word with underscores
        // int indexToHide = rnd.Next(0, wordToHide.word.Length);
        words[rndnum].word = new string('_', wordToHide.word.Length);

        // wordToHide.word = wordToHide.word.Substring(0, indexToHide) + hiddenPart;

        words.RemoveAt(rndnum);
        words.Insert(rndnum, wordToHide);
    }
}
private string ReturnWord()
{
    return word;
}

    public string Exportwords(){
        Hideword();
        List<string> lstring = new();
        foreach (Word word in words){
            string stuff = word.ReturnWord();
            lstring.Add(stuff);
        }
        string fullstring = string.Join(" ",lstring);
        
        return fullstring;
    }

}