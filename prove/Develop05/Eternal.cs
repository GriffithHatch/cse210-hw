class Eternal : Goal{
    private int completion;
    public Eternal() : base(){
        completion = 0;
    }
    public override void Display()
    {
        Console.WriteLine($"[Eternal] {goalname} | {description} | Times Completed - {completion} | {points} points");
    } 
    public override void RecordGoal(int choice)
    {

    }
    public override string Export()
    {
        return base.Export() + $"{DELIMITER}{completion}";
    }
    // public override void DisplayList()
    // {

    //     foreach (Eternal line in goals){
    //         base.DisplayList(); Console.WriteLine($"[{line.completion}]");
    //     }
    // }
}