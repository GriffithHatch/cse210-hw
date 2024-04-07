using System.Diagnostics.Tracing;

class Armor{
    protected string name;
    protected int defence;
    protected int speed;
    public Armor(string value){
        var armorvar = value.Split("|");
        name = armorvar[0];
        defence = int.Parse(armorvar[1]);
        speed = int.Parse(armorvar[2]);
    }
    public Armor(){

    }

    public virtual string ArmorInfo(){
        return $"{name}, attack:{defence}, speed:{speed}"; 
    }

    public int GetDefence(){
        return defence;
    }
    public int GetSpeed(){
        return speed;
    }
    public virtual int GetMaxhp(){
        return 0;
    }
    public static List<Armor> GetArmorLootTable( List<Armor> armors){
        List<Armor> armorlist = new List<Armor>();
        foreach(Armor armor in armors){
            armorlist.Add(armor);
        }
        return armorlist;
    }
    public static string[] ReadFile(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        return lines;
    }
    public static void Load(List<Armor> armors){
        var strings = ReadFile("Armorstats.txt");

        foreach (var line in strings){
            var typestring = line[0..2];
            if (typestring == "A:"){
                armors.Add(new Armor(line[2..]));
            }
            else if (typestring == "S:"){
                armors.Add(new SpecialArmor(line[2..]));
            }
            
        }

    }
}

class SpecialArmor : Armor{
    private int maxhp;
    public SpecialArmor (string value) : base(value.Split("||")[0]){
        maxhp = int.Parse(value.Split("||")[1]);
    }
    public override string ArmorInfo()
    {
        return base.ArmorInfo() + $", maxhp modifier: {maxhp}";
    }
    public override int GetMaxhp()
    {
        return maxhp;
    }
 
}