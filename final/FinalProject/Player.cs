using System.Diagnostics.Tracing;

class Player{
    private int maxhp;
    private int health;
    private int defence;// Armor adds to this stat
    private int speed; // base speed will be 5
    private int truespeed; // This is your current speed caculated by weight and wounds.
    private int weight; // All Items add to this stat, too much weight will slow you down.
    private static List<string> wounds = new List<string>(); // This will store your wounds in a string. Then at the start of each
    // room your current stats will be recacluated. Some actions can heal wounds but the effects will not be realized until a new room is entered
    private int sanity; // This will effect your encounters, less sanity == harder fights
    private int attack;
    public void ListWounds(){
        Console.WriteLine("You have suffered\n");
        foreach(string wound in wounds){
            Console.Write($"{wound}");
        }
    }
    public void WoundEffects(){
        if (wounds.Count == 0)

        foreach(string wound in wounds){
            if(wound == "Lacaration"){
                truespeed -= 1;
                health -= 5;
                attack -= 1;
            }
            if(wound == "Fracture"){
                truespeed -= 1;
                attack -= 3;
                health -= 3;
            }
            if(wound == "Near Fatal"){
                truespeed -= 3;
                attack -= 10;
                health -= 10;
            }
        }
        CheckHealth();
    }
    public void SanityEffects(){

    }
    public void CheckHealth(){
        if (health == 0){
            Console.WriteLine("You have died\n");
        }
    }
}