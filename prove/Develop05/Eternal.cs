class Eternal : Goal{
    private int completion;
    public Eternal() : base(){
        completion = 0;
    }
    public Eternal(string values) :base(values.Split($"{DELIMITER}{DELIMITER}")[0]){
        var simpleVariable = values.Split($"{DELIMITER}{DELIMITER}")[1];
        completion = int.Parse(simpleVariable);
    }
    public override void Display()
    {
        Console.WriteLine($"[Eternal] {goalname} | {description} | Times Completed - {completion} | {points} points");
    } 
    public override void RecordGoal()
    {
        completion += 1;
        totalcompletions += 1;
        totalPoints += points;
    }
    public override string Export()
    {
        return base.Export() + $"{DELIMITER}{DELIMITER}{completion}";
    }
    // public override void DisplayList()
    // {

    //     foreach (Eternal line in goals){
    //         base.DisplayList(); Console.WriteLine($"[{line.completion}]");
    //     }
    // }
}