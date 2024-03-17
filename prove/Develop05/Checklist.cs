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

    public override string Export()
    {
        return base.Export() + $"{DELIMITER}{todo}{DELIMITER}{completed}{DELIMITER}{bonus}";
    }

    public override void RecordGoal(int choice)
    {

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