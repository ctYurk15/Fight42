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
            string act;
            if (health[0] > 0)
            {
                Console.WriteLine("First Player: ");
                act = Convert.ToString(Console.ReadLine());
                Behavior("First", act, ref health[0], ref health[1]);
            }
            else
            {
                Console.WriteLine("Second Player win! P.A.K.T.E.>!!!");
            }
            if (health[1] > 0)
            {
                Console.WriteLine("Second Player:");
                act = Convert.ToString(Console.ReadLine());
                Behavior("Second", act, ref health[1], ref health[0]);
                GameCycle();
            }
            else
                Console.WriteLine("First Player win! P.A.K.T.E.!!!");
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
                case "Foot-Kick":
                    EH = EH - 15;
                    Console.WriteLine($"{player} player kicked with foot another!");
                    Console.WriteLine($"First: {health[0]}hp vs Second: {health[1]}hp");
                    break;
                case "Hand-Kick":
                    EH = EH - 10;
                    Console.WriteLine($"{player} player kicked with hand another!");
                    Console.WriteLine($"First: {health[0]}hp vs Second: {health[1]}hp");
                    break;
                default:
                    Console.WriteLine($"{player} player made nothing!");
                    Console.WriteLine($"First: {health[0]}hp vs Second: {health[1]}hp");
                    break;
            }
        }
    }
}
