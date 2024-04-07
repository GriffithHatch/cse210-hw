using System.Reflection;

class Monsters{
    protected string name;
    protected int health;
    protected int speed;
    protected int defence;
    protected int attack;
    public Monsters(string value){
        var monstervariable = value.Split("|");
        name = monstervariable[0];
        health = int.Parse(monstervariable[1]);
        speed = int.Parse(monstervariable[2]);
        defence = int.Parse(monstervariable[3]);
        attack = int.Parse(monstervariable[4]);
    }
    protected static List<Monsters> monsters = new List<Monsters>();
    // public virtual int GetSpeed(Monsters monster){
    //     return monster.speed;
    // }
    public virtual string GetMonsterInformation(){
        return $"{name}|{health}|{speed}|{defence}|{attack}";
    }
    public virtual string GetMonster(string name){
        foreach(Monsters monster in monsters){
            if(monster.name == name){
                return $"{monster.name}|{monster.health}|{monster.speed}|{monster.defence}|{monster.attack}";
            }
        }
        return null;
    }
    public static string[] ReadFile(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        return lines;
    }
    public static void Load(List<Monsters> monsters){
        var strings = ReadFile("Monsterstats.txt");

        foreach (var line in strings){
            var typestring = line[0..2];
            if (typestring == "M:"){
                monsters.Add(new Monsters(line[2..]));
            }
            else if (typestring == "B:"){
                monsters.Add(new SpecialMonster(line[2..]));
            }
        }

    }
}
class SpecialMonster : Monsters{
    private int dot;
    private int regen;
    public SpecialMonster(string value) : base(value.Split("||")[0]) {
        var specialvar = value.Split("||")[1].Split("|");
        this.dot = int.Parse(specialvar[0]);
        this.regen = int.Parse(specialvar[1]);
    }
    public override string GetMonster(string name)
    {
        return base.GetMonster(name) + $"|{regen}|{dot}";
    }
    public override string GetMonsterInformation()
    {
        return base.GetMonsterInformation() + $"|{regen}|{dot}";
    }


}