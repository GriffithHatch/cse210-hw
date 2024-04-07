using System.Reflection;

class Weapon{
    protected string name;
    protected int attack;
    protected int speed;

    public Weapon (string value){
        var weaponvariables = value.Split("|");
        name = weaponvariables[0];
        attack = int.Parse(weaponvariables[1]);
        speed = int.Parse(weaponvariables[2]);
    }
    public Weapon(){

    }
    public string GetName(){
        return name;
    }
    public int GetAttack(){
        return attack;
    }
    public int GetSpeed(){
        return speed;
    }
    public virtual int GetMaxhp(){
        return 0;
    }

    public static Weapon GetWeapon(List<Weapon> weapons,string name){
        foreach (Weapon weapon in weapons){
            if (weapon.name == name){
                return weapon;
            }
        }
        return null;
    }

    public static List<Weapon> GetWeaponsLootTable(List<Weapon> weapons){
        List<Weapon> weaponlist = new List<Weapon>();
        foreach(Weapon weapon in weapons){
            if(weapon is SpecialWeapon){

            }
            else{
                weaponlist.Add(weapon);
            }
        }
        return weaponlist;
    }
    public static string[] ReadFile(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        return lines;
    }

    public static void Load(List<Weapon> weapons){
        var strings = ReadFile("Weaponstats.txt");

        foreach (var line in strings){
            var typestring = line[0..2];
            if (typestring == "W:"){
                weapons.Add(new Weapon(line[2..]));
            }
            else if (typestring == "S:"){
                weapons.Add(new SpecialWeapon(line[2..]));
            }
            
        }

    }
    

public virtual string WeaponInfo(){
    return $"{name}, attack:{attack}, speed:{speed}";
}

public virtual void DisplayWeapon(){
    Console.WriteLine($"{name} {attack} {speed}");
}
}


class SpecialWeapon : Weapon{
    private int maxhp;
    public SpecialWeapon(string value) : base(value.Split("||")[0]){
        maxhp = int.Parse(value.Split("||")[1]);
    }
    public override void DisplayWeapon()
    {
        Console.WriteLine($"{name} {attack} {speed} {maxhp}");
    }
    public override int GetMaxhp()
    {
        return maxhp;
    }
    public override string WeaponInfo()
    {
        return base.WeaponInfo() + $", maxhp modifier: {maxhp}";
    }

}