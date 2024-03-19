using System.Reflection.Metadata;

class Simple : Goal{
    private bool done;
    public Simple() : base(){
        done = false;
    }
    public Simple(string values) :base(values.Split($"{DELIMITER}{DELIMITER}")[0]){
        var simpleVariable = values.Split($"{DELIMITER}{DELIMITER}")[1];
        done = bool.Parse(simpleVariable);
    }

    public override void RecordGoal()
    {
        done = true;
        totalcompletions += 1;
        totalPoints += points;
    }
    public override void Display()
    {
        if(done == true){
            Console.WriteLine($"[Complete] {goalname} | {description} | {points} points");
        }
        else{
            Console.WriteLine($"[] {goalname} | {description} | {points} points");
        }
        

    }
    public override string Export()
    {
        return base.Export() + $"{DELIMITER}{DELIMITER}{done}";
    }

    // public override void DisplayList()
    // {

    //     foreach (Simple line in goals){
    //         if(line.done == true){

    //         base.DisplayList(); Console.Write("| [Completed]");
    //         }
    //         else{
    //             base.DisplayList(); Console.Write("[]");
    //         }
    //     }

    // }
}