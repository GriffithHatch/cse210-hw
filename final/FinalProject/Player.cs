using System.ComponentModel.Design;
using System.Diagnostics.Tracing;
using System.Xml.Serialization;

class Player{
    private string name; 
    private int maxhp;
    private int health;
    private Weapon weapon;
    private Armor armor;
    private int defence;// Armor adds to this stat
    private int speed; // base speed will be 5
    private int truespeed; // This is your current speed caculated by weight and wounds.
    private int sanity; // This will effect your encounters, less sanity == harder fights
    private int attack; // base attack always 5 can never be changed
    private bool dead;
    private static List<string> inventory = new List<string>();
    public Player(Armor armor, Weapon weapon,string consumable){
        Console.WriteLine("What is your name?");
        name = Console.ReadLine();
        maxhp = 50;
        defence = 0;
        health = 50;
        speed = 5;
        truespeed = speed;
        sanity = 100;
        attack = 5;
        this.armor = armor;
        this.weapon = weapon;
        inventory.Add(consumable);
        dead = false;
    }
    public Player (List<Armor> armor, List<Weapon> weapon, string consumable){
        Console.WriteLine("What is your name?");
        name = Console.ReadLine();
        maxhp = 50;
        defence = 0;
        health = 50;
        speed = 5;
        truespeed = speed;
        sanity = 100;
        attack = 5;
        
        
        inventory.Add(consumable);
        dead = false;
    }

    public void EquipStats(){
        truespeed = speed + weapon.GetSpeed() + armor.GetSpeed();
        attack = 5 + weapon.GetAttack();
        defence = armor.GetDefence();
        maxhp = 50 + weapon.GetMaxhp() + armor.GetMaxhp();
        if (health > maxhp){
            health = maxhp;
        }
    }

    public string CheckStats(){
        return $"Maxhp: {maxhp}\n health: {health}\n defence: {defence}\n speed: {truespeed}\n sanity: {sanity}\n attack: {attack}";
        
    }
    public void ReturnHp(int hp){
        health = hp;
    }
    public bool CheckDead(){
        return dead;
    }

    public string Armorinfo(){
        return armor.ArmorInfo();
    }

    public string Weaponinfo(){
       return weapon.WeaponInfo();
    }

    public void ReplaceArmor(Armor armor){
        this.armor = armor;
        EquipStats();
    }

    public void ReplaceWeapon(Weapon weapon){
        this.weapon = weapon;
        EquipStats();  
    }
    public void Heal(int heal){
        health += heal;
        if (health > maxhp){
            health = maxhp;
        }
    }
    public void AddInventory(string item){
        inventory.Add(item);
    }


    public virtual string GetPlayerInformation(){
        return $"{name}|{health}|{truespeed}|{defence}|{attack}";
    }
    public void SanityEffects(){
        if(sanity >= 80){
            health += 5;
            if(health > maxhp){
                health = maxhp;
            }
        }
        if(sanity < 80 && sanity >= 40){
            Console.WriteLine("You feel a dull pain in the back of your head");
        }
        if(sanity < 40 && sanity >= 15){
            health -= 10;
            Console.WriteLine("You head is under great stress. You feel yourself getting weaker");
        }
        if(sanity < 15 && sanity >= 5){
            Console.WriteLine("The walls are caving in you are about to break");
            health -= 20;
        }
        if(sanity < 5){
            Console.WriteLine("Due to stress you have suffered a heart attack and have died");
            health = 0;
        }
        CheckHealth();
    }


    public void CheckHealth(){
        if (health <= 0){
            dead = true;
        }
    }


    public void LostSanity(){
        sanity -= 5;
    }


    public void Inventory(){
        while(inventory.Count() > 3){
            Console.WriteLine("You have to many potions you must drop something");
            int count = 0;
            foreach(string item in inventory){
                count += 1;
                Console.WriteLine($"{count}. {item}");
            Console.WriteLine("What would you like to drop? ");
            int choice = int.Parse(Console.ReadLine()) - 1;
            inventory.Remove(inventory[choice]);
                
            }
        }
        int count1 = 0;
        Console.WriteLine("In your inventory you have:");
        foreach(string item in inventory){
            count1 += 1;
            Console.WriteLine($"{count1}. {item}");
        }
        Console.WriteLine("Would you like to use an item? (Y/N)");
        string choice1 = Console.ReadLine();
        if(choice1 == "Y"){
            count1 = 0;
            Console.WriteLine("Which Item would you like to use?");
            foreach(string item in inventory){
                count1 += 1;
                Console.WriteLine($"{count1}. {item}");
            }
            int choice2 = int.Parse(Console.ReadLine()) - 1;

            if (inventory[choice2] == "Health Potion"){
                health += 10;
                if (health > maxhp){
                    health = maxhp;
                }
                inventory.Remove(inventory[choice2]);
            }
            if (inventory[choice2] == "Speed Potion"){
                speed += 1;
                truespeed += 1; //this allows an immediate effect while adding to base speed to keep the potion effect after re-equiping
                inventory.Remove(inventory[choice2]);
                EquipStats();
            }

            if (inventory[choice2] == "Torch"){
                sanity += 40;
                inventory.Remove(inventory[choice2]);
            }

        }
        else{
            Console.WriteLine("You return focus to the task at hand");
        }

    }
}