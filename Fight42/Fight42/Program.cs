using System;

namespace Fight42
{
    class Program
    {
        //variables of health players
        public static int[] health = { 100, 100 };
        

        //main method
        static void Main(string[] args)
        {
            Console.WriteLine("|Welcome to Fight42! Lets Start!|");
            GameCycle();
            Console.ReadKey();
        }

        //game cycle, return result
        static void GameCycle()
        {
            string action = "Empty";
            if(health[0] > 0)
            {
                Console.Write("|First Player  |: ");
                action = Console.ReadLine();
                Behavior("First", action, ref health[0], ref health[1]);
                if(health[1] > 0)
                {
                    Console.Write("|Second Player |: ");
                    action = Console.ReadLine();
                    Behavior("Second", action, ref health[1], ref health[0]);
                    GameCycle();
                }
                else
                {
                    Console.WriteLine("|Second Player wins!|");
                }
            }
            else
            {
                Console.WriteLine("|First Player wins!|");
            }

        }

        //Actions
        static void Behavior(string player, string do_act, ref int PH, ref int EH)
        {
            switch(do_act)
            {
                //healthing
                case "Health":
                    //-----------//  dont let up HP higher than 100                       
                    if (PH < 89)                          
                    {                                       
                        PH += 12;                          
                        Console.WriteLine("|+12 HP|");    
                    }
                    else
                    {
                        Console.WriteLine($"|+{100 - PH}|");
                        PH = 100;
                    }
                    //---------//
                    Console.WriteLine($"|{player} player healed self!|");
                    Console.WriteLine($"First: {health[0]}hp vs Second: {health[1]}hp");
                    break;
                //kicking
                case "Kick":
                    if(EH <= 15)
                    {
                        Console.WriteLine("|Footballer fatality!|");
                    }
                    else
                    {
                        Console.WriteLine($"|-15 HP|\n|{player} player kicked with foot another!|");
                    }
                    EH = EH - 15;
                    Console.WriteLine($"|First: {health[0]}hp vs Second: {health[1]}hp|");
                    break;
                //hit with hand
                case "Hand-Hit":
                    if (EH <= 10)
                        Console.WriteLine("Boxer Fatality!");
                    else
                        Console.WriteLine($"|-10 HP|\n|{player} player kicked with hand another!|");
                    EH = EH - 10;
                    Console.WriteLine($"|First: {health[0]}hp vs Second: {health[1]}hp|");
                    break;
                //vampirizm
                case "Vampirizm":
                    if(EH >= 9)
                    {
                        EH = EH - 9;
                        if(PH < 92)
                        {
                            PH = PH + 9;
                            Console.WriteLine("|+9 HP|");
                        }
                        else
                        {
                            Console.WriteLine($"|+{100 - PH}|");
                            PH = 100;
                        }
                        Console.WriteLine("|-9 HP|");
                        Console.WriteLine($"|{player} taked some HP from another|");
                        Console.WriteLine($"|First: {health[0]}hp vs Second: {health[1]}hp|");
                    }
                    else
                    {
                        EH = 0;
                        Console.WriteLine("|Another player was too weak and dead in proccess.|\n|Vampir Fatality!|");
                    }
                    break;
                //nothing
                default:
                    Console.WriteLine($"{player} player made nothing!");
                    Console.WriteLine($"First: {health[0]}hp vs Second: {health[1]}hp");
                    break;
            }
        }
    }
}
