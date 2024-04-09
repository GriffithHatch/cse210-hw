using System.ComponentModel.Design;

class Battle{
    public bool BeginCombat(Player player, Monsters monster){
        var playerinfo = player.GetPlayerInformation();
        var playersplit = playerinfo.Split("|");
        string pname = playersplit[0];
        int phealth = int.Parse(playersplit[1]);
        int pspeed = int.Parse(playersplit[2]);
        int pdefence = int.Parse(playersplit[3]);
        int pattack = int.Parse(playersplit[4]);
        int playerattacks = 1;
        int ptempdefence = pdefence;
        bool ran = false;


        var monsterinfo = monster.GetMonsterInformation();
        var monstersplit = monsterinfo.Split("|");
        string mname = monstersplit[0];
        int mhealth = int.Parse(monstersplit[1]);
        int mspeed = int.Parse(monstersplit[2]);
        int mdefence = int.Parse(monstersplit[3]);
        int mattack = int.Parse(monstersplit[4]);
        int regen = 0;
        int dot = 0;
        if(monstersplit.Count() >= 6){
            regen = int.Parse(monstersplit[5]);
        }
        if(monstersplit.Count() >= 7){
            dot = int.Parse(monstersplit[6]);
        }
        int monsterattacks = 1;
        int mtempdefence = mdefence;





        var firstattack = false; // if this is false monster attacks first if true player attacks first
        if(pspeed >= mspeed){
            firstattack = true;
            if (pspeed >= mspeed + 4){
                playerattacks = 3;
            }
            else if (pspeed >= mspeed + 2){
                playerattacks = 2;
            }
        else if(mspeed > pspeed){
            firstattack = false;
            if (mspeed >= pspeed + 4){
                monsterattacks = 3;
            }
            else if(mspeed > pspeed + 2){
                monsterattacks = 2;
            }
        }

        }
        while(phealth > 0 && mhealth > 0 && ran == false){
        int attackcount = 1;
        int menu;
        mhealth += regen;
        Console.WriteLine($"You have {phealth} health");
        Console.WriteLine($"{mname} has {mhealth} health");

        if(firstattack == true){
            ptempdefence = pdefence; // this way players don't get a permanent buff to their defence.

            while(attackcount <= playerattacks){
                try{
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Attack\n 2.Defend\n 3. Run Away");
                menu = int.Parse(Console.ReadLine());

                switch(menu){
                    case 1:
                    mhealth = PlayerAttack(pname,pattack,mtempdefence,mhealth);
                    break;
                    case 2:
                    ptempdefence = Defend(pdefence);
                    break;
                    case 3:
                    ran = RunAway(mspeed,pspeed);
                    break;
                    default:
                    Console.WriteLine("Due to your lacking of choosing a proper answer, You lose a turn!");
                    break;

                }
                }
                catch(Exception e){}
                attackcount += 1;
            }
            if(mhealth <= 0){

            }
            else{

                mtempdefence = mdefence;
                attackcount = 1;
                while(attackcount <= monsterattacks){
                    Console.WriteLine(monsterattacks);
                    Random rng = new();
                    int monsteraction = rng.Next(1,10);
                    if (monsteraction > 3){
                        phealth = MonsterAttack(mname,ptempdefence, mattack, phealth);
                    }
                    else{
                        Console.WriteLine($"The {mname} defends");
                        mtempdefence = Defend(mdefence);
                    }
                    attackcount += 1;
                }
                
            }   
        }


        else{
            mtempdefence = mdefence;
            attackcount = 1;
            while(attackcount <= monsterattacks){
                Random rng = new();
                int monsteraction = rng.Next(1,10);
                if (monsteraction > 3){
                    phealth = MonsterAttack(mname,ptempdefence, mattack, phealth);
                }
                else{
                    mtempdefence = Defend(mdefence);
                }
                attackcount += 1;
            }


            attackcount = 1;
            while(attackcount <= playerattacks){
                try{
                Console.WriteLine("What would you like to do?");
                Console.WriteLine("1. Attack\n 2.Defend\n 3. Run Away");
                menu = int.Parse(Console.ReadLine());
                switch(menu){
                    case 1:
                    mhealth = PlayerAttack(pname,pattack,mtempdefence,mhealth);
                    break;
                    case 2:
                    ptempdefence = Defend(pdefence);
                    break;
                    case 3:
                    ran = RunAway(mspeed,pspeed);
                    break;
                    default:
                    Console.WriteLine("Due to your lacking of choosing a proper answer, You lose a turn!");
                    break;
                }
                }
                catch(Exception e){}
                attackcount += 1;
            }

        }
        phealth -= dot;
    }
    Console.Clear();
    player.ReturnHp(phealth);
    return ran;
    }


    public int PlayerAttack(string pname, int pattack, int mdefence,int mhealth){
        int dmgdealt = 0;
        if(pattack > mdefence){
            dmgdealt = pattack - mdefence + (pattack/4);
        }
        if(pattack <= mdefence){
            dmgdealt = (pattack / 2) + 1;
        }
        if(dmgdealt < 1){
            dmgdealt = 1;
        }
        Console.WriteLine($"{pname} Attacks for {dmgdealt} damage");
        mhealth -= dmgdealt;
        return mhealth;
    }


    public int MonsterAttack(string mname, int pdefence, int mattack, int phealth){
        int dmgdealt = 0;
        if(mattack > pdefence){
            dmgdealt = (mattack - pdefence) + (mattack/2) - 1;
        }
        if(mattack <= pdefence){
            dmgdealt = (mattack / 2) - 1;
        }
        if(dmgdealt < 1){
            dmgdealt = 1;
        }
        Console.WriteLine($"{mname} attacks for {dmgdealt} damage");
        phealth -= dmgdealt;
        return phealth;
    }

    public void Stealth(){

    }
    public int Defend(int defence){
        int tempdefence = defence + 10;
        return tempdefence;
    }
    public bool RunAway(int mspeed,int pspeed){
        if(pspeed > mspeed){
            return true;
        }
        if (pspeed <= mspeed){
            Random rng = new();
            var coinflip = rng.Next(1,2);
            if (coinflip == 1){
                return true;
            }
            else{
                return false;
            }
        
        }
        return false;
    }


}