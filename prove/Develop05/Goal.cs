using System.ComponentModel.DataAnnotations;
using System.IO.Pipes;
using System.Xml.Schema;


// I need to add Constroctors to each class for it to properly bring back the information from the file. But my headache won't leave
// I just so tired today. it really sucks but I will have to finish this tomorrow.




abstract class Goal{
    public static readonly string DELIMITER = "|";
    // private static int count;
    protected int points;
    // protected int totalPoints;
    protected string goalname;
    protected string description;
    public static List<Goal> goals = new List<Goal>();
    public Goal (){
        Console.WriteLine("What is the name of your goal?");
        goalname = Console.ReadLine();
        Console.WriteLine("Give a small description of your goal");
        description = Console.ReadLine();
        Console.WriteLine("How many points does this goal give on completion?");
        points = int.Parse(Console.ReadLine());

    }
    public virtual string Export(){
        return $"{goalname}{DELIMITER}{description}{DELIMITER}{points}";
    }

        public static void WriteFile(string fileName, string content)
    {
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.Write(content);
        }
    }

    public void Save(string filename, List<Goal> goals){
        var data = "";
        foreach(var goal in goals)
        {
            var typestring = "";
            if(goal is Simple)
            {
                typestring = "S:";
            }
            else if (goal is Eternal){
                typestring = "E:";
            }
            else if (goal is Checklist){
                typestring = "C:";
            }
            data += typestring + goal.Export() + "\n";
        }
        WriteFile(filename, data);
    }

    public static string[] ReadFile(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        return lines;
    }

    public void Load(string filename){
        var strings = ReadFile(filename);

        foreach (var line in strings){
            var typestring = line[0..2];
            if (typestring == "S:"){
                goals.Add(new Simple(line[2..]));
            }
            else if (typestring == "E:"){
                goals.Add(new Eternal(line[2..]));
            }
            else if (typestring == "C:"){
                goals.Add(new Checklist(line[2..]));
            }
        }

    }
    public abstract void Display();//{
        // foreach(Goal line in goals){
            // Console.WriteLine($"{line.goalname} | {line.description} | {line.points} points");
        // }
    //}
    // public virtual void DisplayList(){
    //     count = 0;
    //     foreach (Goal line in goals){
    //         count += 1;
    //         Console.WriteLine($"{count}. {line.goalname} | {line.description} | {line.points}");
    // }
    // }
    public abstract void RecordGoal(int choice);

}