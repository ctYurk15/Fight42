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
            Console.WriteLine("Welcome to Fight42! Lets Start!");
            GameCycle();
            Console.ReadKey();
        }

        //game cycle, return result
        static void GameCycle()
        {
            string action = "Empty";
            if(health[0] > 0)
            {
                Console.Write("|First Player  |");
                action = Console.ReadLine();
                Behavior("First", action, ref health[0], ref health[1]);
                if(health[1] > 0)
                {
                    Console.Write("|Second Player |");
                    action = Console.ReadLine();
                    Behavior("Second", action, ref health[1], ref health[0]);
                    GameCycle();
                }
                else
                {
                    Console.WriteLine("Second Player wins!");
                }
            }
            else
            {
                Console.WriteLine("First Player wins!");
            }

        }

        //Actions
        static void Behavior(string player, string do_act, ref int PH, ref int EH)
        {
            switch(do_act)
            {
                case "Health":
                    PH = PH + 12;
                    Console.WriteLine($"{player} player healed self!");
                    Console.WriteLine($"First: {health[0]}hp vs Second: {health[1]}hp");
                    break;
                case "Kick":
                    EH = EH - 15;
                    Console.WriteLine($"{player} player kicked with foot another!");
                    Console.WriteLine($"First: {health[0]}hp vs Second: {health[1]}hp");
                    break;
                case "Hand-Hit":
                    EH = EH - 10;
                    Console.WriteLine($"{player} player kicked with hand another!");
                    Console.WriteLine($"First: {health[0]}hp vs Second: {health[1]}hp");
                    break;
                case "Vampirizm":
                    if(EH >= 9)
                    {
                        EH = EH - 9;
                        PH = PH + 9;
                        Console.WriteLine($"{player} taked some HP from another");
                        Console.WriteLine($"First: {health[0]}hp vs Second: {health[1]}hp");
                    }
                    else
                    {
                        EH = 0;
                        Console.WriteLine("Another player was too weack and dead in proccess.");
                    }
                    break;
                default:
                    Console.WriteLine($"{player} player made nothing!");
                    Console.WriteLine($"First: {health[0]}hp vs Second: {health[1]}hp");
                    break;
            }
        }
    }
}
