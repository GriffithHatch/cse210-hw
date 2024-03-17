using System.Reflection.Metadata;

class Simple : Goal{
    private bool done;
    public Simple() : base(){
        done = false;
    }

    public override void RecordGoal(int choice)
    {
        var goal = goals[choice];
        
        
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
        return base.Export() + $"{DELIMITER}{done}";
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