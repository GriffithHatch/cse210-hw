using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

class Dungeon{
    protected string description;
    public Dungeon(string value){
        description = value;
    }
    public Dungeon(){

    }
    private static List<Monsterroom> monsterrooms = new List<Monsterroom>();
    private static List<Saferoom> saferooms = new List<Saferoom>();
    private static List<LootRoom> lootrooms = new List<LootRoom>();


    public virtual void RoomEffect(Player mercenary){
        Console.WriteLine(description);

    }
    public void GenerateRoom(Player mercenary, List<Armor> armor, List<Weapon> weapon, List<Monsters> monsters){
        Random randomize = new();
        var roomsgenerated = randomize.Next(1,4);
        Console.WriteLine($"{roomsgenerated} rooms");
        switch(roomsgenerated){
            case 1:
            var endroomindex = monsterrooms.Count() - 1;
            var randomroom = randomize.Next(0,endroomindex);
            monsterrooms[randomroom].RoomLoot(armor,weapon,monsters);
            monsterrooms[randomroom].RoomEffect(mercenary);
            break;
            case 2:
            var endroomindex1 = saferooms.Count() - 1;
            var randomroom1 = randomize.Next(0,endroomindex1);
            saferooms[randomroom1].RoomEffect(mercenary);
            
            break;
            case 3:
            var endroomindex2 = lootrooms.Count() - 1;
            var randomroom2 = randomize.Next(0,endroomindex2);
            lootrooms[randomroom2].RoomLoot(armor,weapon);
            lootrooms[randomroom2].RoomEffect(mercenary);
            
            break;
        }
    
    }
    public static string[] ReadFile(string fileName)
    {
        string[] lines = File.ReadAllLines(fileName);
        return lines;
    }

    public void Load(){
        var strings = ReadFile("RoomDescriptions.txt");

        foreach (var line in strings){
            var typestring = line[0..2];
            if (typestring == "M:"){
                monsterrooms.Add(new Monsterroom(line[2..]));
            }
            else if (typestring == "S:"){
                saferooms.Add(new Saferoom(line[2..]));
            }
            else if (typestring == "L:"){
                lootrooms.Add(new LootRoom(line[2..]));
            }
        }

    }
}
class Monsterroom : Dungeon{

    private string loottable;
    private bool ranaway = false;
    private Armor armor = null;
    private Weapon weapon = null;
    private Monsters monster;
    public Monsterroom(string value) : base(value.Split("||")[0]){
        loottable = value.Split("||")[1];
    }


    public void RoomLoot(List<Armor> armor, List<Weapon> weapon, List<Monsters> monsters){
        Random randomize = new();

        if (loottable == "armor"){
            var elements = armor.Count()-1;
            int pick = randomize.Next(0,elements);
            this.armor = armor[pick];

        }
        else if(loottable == "weapon"){
            var elements = weapon.Count()-1;
            int pick = randomize.Next(0,elements);
            this.weapon = weapon[pick];
        }
        var melements = monsters.Count() - 1;
        int mpick = randomize.Next(0,melements);
        this.monster = monsters[mpick];
    }

    public override void RoomEffect(Player mercenary)
    {
        base.RoomEffect(mercenary);
        Battle instB = new();
        ranaway = instB.BeginCombat(mercenary,monster);
        mercenary.CheckHealth();
        if(mercenary.CheckDead()){

        }
        else if(ranaway == true){

        }
        else{
            if(armor != null){
                Console.WriteLine("You have won this combat and armor is left behind");
                Console.WriteLine($"Your armor is {mercenary.Armorinfo()}");
                Console.WriteLine($"Dropped armor is {armor.ArmorInfo()}");
                Console.WriteLine("Would you like to equip this new armor? (Y/N)");
                var choice = Console.ReadLine();
                if (choice == "Y"){
                    mercenary.ReplaceArmor(armor);
                }
            }
            else if(weapon != null){
                Console.WriteLine("You have won this combat and a Weapon is left behind");
                Console.WriteLine($"Your Weapon is {mercenary.Weaponinfo()}");
                Console.WriteLine($"Dropped Weapon is {weapon.WeaponInfo()}");
                Console.WriteLine("Would you like to equip this new weapon? (Y/N)");
                var choice = Console.ReadLine();
                if (choice == "Y"){
                    mercenary.ReplaceWeapon(weapon);
                }

            }

        }
        weapon = null;
        armor = null;
    }

}
class Saferoom : Dungeon{
    public Saferoom(string value) : base(value.Split("||")[0]){
        heal = int.Parse(value.Split("||")[1]);
    }
    private int heal;
    public override void RoomEffect(Player mercenary){
        Console.WriteLine($"You woulds seem to close! You heal {heal} hp");
        mercenary.Heal(heal);
        mercenary.StressHeal(heal);

    }

}
class LootRoom : Dungeon{
    public LootRoom(string value) : base(value.Split("||")[0]){
        var lootvariables = value.Split("||")[1].Split("|");
        loottable = lootvariables[0];
        consumable = lootvariables[1];
        }

    private string loottable;
    private string consumable;
    private Armor armor;
    private Weapon weapon;
    public void RoomLoot(List<Armor> armor, List<Weapon> weapon){
        Random randomize = new();

        if (loottable == "armor"){
            var loot = Armor.GetArmorLootTable(armor);
            var elements = loot.Count()-1;
            int pick = randomize.Next(0,elements);
            this.armor = loot[pick];

        }
        else if(loottable == "weapon"){
            var loot = Weapon.GetWeaponsLootTable(weapon);
            var elements = loot.Count()-1;
            int pick = randomize.Next(0,elements);
            this.weapon = loot[pick];
        }
    }
    public override void RoomEffect(Player mercenary)
    {
        if(armor != null){
                Console.WriteLine("You found useable armor in the room");
                Console.WriteLine($"Your armor is {mercenary.Armorinfo()}");
                Console.WriteLine($"Dropped armor is {armor.ArmorInfo()}");
                Console.WriteLine("Would you like to equip this new armor? (Y/N)");
                var choice = Console.ReadLine();
                if (choice == "Y"){
                    mercenary.ReplaceArmor(armor);
                }
                armor = null;
            }
            else if(weapon != null){
                Console.WriteLine("You found a usable weapon in the room");
                Console.WriteLine($"Your Weapon is {mercenary.Weaponinfo()}");
                Console.WriteLine($"Dropped Weapon is {weapon.WeaponInfo()}");
                Console.WriteLine("Would you like to equip this new armor? (Y/N)");
                var choice = Console.ReadLine();
                if (choice == "Y"){
                    mercenary.ReplaceWeapon(weapon);
                }
                weapon = null;
            }
            mercenary.AddInventory(consumable);
            
    }


}