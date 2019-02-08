using System;

namespace Fight42
{
    class Program
    {
        //data of players(hp, kicks, all damage, coeficient of damage)
        public static double[] data1 = { 10.0, 0.0, 0.0, 1.0 };
        public static double[] data2 = { 10.0, 0.0, 0.0, 1.0 };

        //just norma for kicks
        public static int kicks_norma = 6;

        //just norma for damage
        public static int damage_norma = 30;

        //make power of players bigger
        static void ivents()
        {
            //kicks
            if(data1[1] > kicks_norma)
            {
                data1[3] += 0.5;
                kicks_norma = kicks_norma * 2;
                Console.WriteLine($"|Force of First player is bigger than before!(multiplier = {data1[3]})|");
            }
            else if(data2[1] > kicks_norma)
            {
                data2[3] += 0.5;
                kicks_norma = kicks_norma * 2;
                Console.WriteLine($"|Force of Second player  is bigger!(multiplier = {data2[3]})|");
            }

            //damage
            if(data1[2] > damage_norma)
            {
                damage_norma = damage_norma + (damage_norma / 2);
                data1[0] += 5;
                Console.WriteLine("|First player get + 5HP!|");
            }
            else if (data2[2] > damage_norma)
            {
                damage_norma = damage_norma + (damage_norma / 2);
                data2[0] += 5;
                Console.WriteLine("|Second player get + 5HP!|");
            }

            //weaking
            if (data1[0] < 10)
            {
                data1[3] -= 0.2;
                Console.WriteLine($"|First player is weaking!(multiplier = {data1[3]})|");
            }
            else if (data2[0] < 10)
            {
                data2[3] -= 0.2;
                Console.WriteLine($"|Second player is weaking!(multiplier = {data2[3]})|");
            }
        }

        static void lOGO()
        {
            Console.WriteLine("***************************************************");
            Console.WriteLine("*-|||||--@-|||||||-|---|-|||||||---/-----|-/||||||*");
            Console.WriteLine("*-|--------|-------|---|----|------|-----|-------|*");
            Console.WriteLine("*-|||||--|-|-------|||||----|------|||||||-------|*");
            Console.WriteLine("*-|------|-|---||--|---|----|------------|-/||||||*");
            Console.WriteLine("*-|------|-|-----|-|---|----|------------|-|------*");
            Console.WriteLine("*-|------|-|||||||-|---|----|------------|-|||||||*");
            Console.WriteLine("***************************************************");
        }

        static void End_statistics(string winner)
        {
            Console.WriteLine($"|Winner - {winner} player|");
            Console.WriteLine("|First player:|");
            Console.WriteLine($"|Total kicks: {data1[1]} Total damage: {data1[2]}|");
            Console.WriteLine("|Second player:|");
            Console.WriteLine($"|Total kicks: {data2[1]} Total damage: {data2[2]}|");
        }


        //main method
        static void Main(string[] args)
        {
            lOGO();
            Console.WriteLine("|Welcome to Fight42!|\n|Press Enter to start!|");
            Console.ReadKey();
            GameCycle();
            Console.ReadKey();
        }

        //game cycle, return result
        static void GameCycle()
        {
            string action = "Empty";
            if(data1[0] > 0)
            {
                ivents();
                Console.Write("|First Player  |: ");
                action = Console.ReadLine();
                Behavior("First", action, ref data1, ref data2);
                if(data2[0] > 0)
                {
                    ivents();
                    Console.Write("|Second Player |: ");
                    action = Console.ReadLine();
                    Behavior("Second", action, ref data2, ref data1);
                    GameCycle();
                }
                else
                {
                    End_statistics("First");
                }
            }
            else
            {
                End_statistics("Second");
            }

            Console.WriteLine("|Do you what again?|");
            string chs = Console.ReadLine();
            if (chs == "yes")
            {
                data1[0] = data2[0] = 100;
                data1[1] = data1[2] = data2[1] = data2[2] = 0;
                data1[3] = data2[3] = 1;
                kicks_norma = 6;
                damage_norma = 30;
                Console.WriteLine("Lets do it!");
                GameCycle();
            }
                
        }

        //Actions
        static void Behavior(string player, string do_act, ref double[] PD, ref double[] ED)
        {
            switch(do_act)
            {
                //healthing
                case "Health":
                    //-----------//  dont let up HP higher than 100                       
                    if (PD[0] < 89)                          
                    {                                       
                        PD[0] += 12;                          
                        Console.WriteLine("|+12 HP|");    
                    }
                    else
                    {
                        Console.WriteLine($"|+{100 - PD[0]}|");
                        PD[0] = 100;
                    }
                    //---------//
                    Console.WriteLine($"|{player} player healed self!|");
                    Console.WriteLine($"First: {data1[0]}hp vs Second: {data2[0]}hp");
                    break;
                //kicking
                case "Kick":
                    PD[1] += 1;
                    if (ED[0] <= 15 * PD[3])
                    {
                        PD[2] += ED[0];
                        ED[0] = 0;
                        Console.WriteLine("|Footballer fatality!|");
                    }
                    else
                    {
                        PD[2] += 15 * PD[3];
                        ED[0] = ED[0] - 15 * PD[3];
                        Console.WriteLine($"|-{15 * PD[3]} HP|\n|{player} player kicked with foot another!|");
                        Console.WriteLine($"|First: {data1[0]}hp vs Second: {data2[0]}hp|");
                    }
                    break;
                //hit with hand
                case "Hand-Hit":
                    PD[1] += 2;
                    if (ED[0] <= 8 * PD[3])
                    {
                        PD[2] += ED[0];
                        ED[0] = 0;
                        Console.WriteLine("Boxer Fatality!");
                    }
                    else
                    {
                        PD[2] += 8 * PD[3];
                        Console.WriteLine($"|-{8 * PD[3]} HP|\n|{player} player kicked with hand another!|");
                        ED[0] = ED[0] - 8 * PD[3];
                        Console.WriteLine($"|First: {data1[0]}hp vs Second: {data2[0]}hp|");
                    }
                    break;
                //vampirizm
                case "Vampirizm":
                    PD[1] += 1;
                    if(ED[0] > 11)
                    {
                        ED[0] = ED[0] - 11;
                        PD[2] += 11;
                        if(PD[0] < 92)
                        {
                            PD[0] = PD[0] + 9;
                            Console.WriteLine("|+9 HP|");
                        }
                        else
                        {
                            Console.WriteLine($"|+{100 - PD[0]}|");
                            PD[0] = 100;
                        }
                        Console.WriteLine("|-11 HP|");
                        Console.WriteLine($"|{player} taked some HP from another|");
                        Console.WriteLine($"|First: {data1[0]}hp vs Second: {data2[0]}hp|");
                    }
                    else
                    {
                        PD[2] += ED[0];
                        ED[0] = 0;
                        Console.WriteLine("|Another player was too weak and dead in proccess.|\n|Vampir Fatality!|");
                    }
                    break;
                //nothing
                default:
                    Console.WriteLine($"{player} player made nothing!");
                    Console.WriteLine($"First: {data1[0]}hp vs Second: {data2[0]}hp");
                    break;
            }
        }
    }
}
