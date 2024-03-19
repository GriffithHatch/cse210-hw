class Checklist : Goal{
    private int todo;
    private int completed;
    private int bonus;
    public Checklist() : base(){
        Console.WriteLine("How many times would you like to complete this goal before it is fully completed");
        todo = int.Parse(Console.ReadLine());
        Console.WriteLine("How many bonus points would you like for completing this goal?");
        bonus = int.Parse(Console.ReadLine());
        completed = 0;

    }
public Checklist(string values) :base(values.Split($"{DELIMITER}{DELIMITER}")[0]){
        var checkVariable = values.Split($"{DELIMITER}{DELIMITER}")[1].Split(DELIMITER);
        todo = int.Parse(checkVariable[0]);
        completed = int.Parse(checkVariable[1]);
        bonus = int.Parse(checkVariable[2]);
    }

    public override string Export()
    {
        return base.Export() + $"{DELIMITER}{DELIMITER}{todo}{DELIMITER}{completed}{DELIMITER}{bonus}";
    }

    public override void RecordGoal()
    {
        todo += 1;
        totalcompletions += 1;
        if (todo == completed){
            totalPoints += points;
            totalPoints += bonus;
        }
        else{
            totalPoints += points;
        }
    
    }
    public override void Display()
    {
        if(todo == completed){
            Console.WriteLine($"[Completed] {goalname} | {description} | {points} points | {bonus} bonus points");
        }
        else{
            Console.WriteLine($"[{completed}/{todo}] {goalname} | {description} | {points} points | {bonus} bonus points");
        }
    }
    // public override void DisplayList()
    // {
    //     foreach (Checklist line in goals){
    //        base.DisplayList(); Console.Write($"[{line.completed}/{line.todo}] | {line.bonus} ");
    //     }
    // }
}