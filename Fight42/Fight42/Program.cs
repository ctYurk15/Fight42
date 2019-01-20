using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fight42
{
    class Program
    {
        //variables of health players
        public static int[] health = { 100, 100 };
        

        //main method
        static void Main(string[] args)
        {
            string act , f= "First", s = "Second";
            Console.WriteLine("Welcome to Fight42! Lets Start!");
            while(health[0] > 0 && health[1] > 0)
            {
                Console.WriteLine("First Player: ");
                act = Convert.ToString(Console.ReadLine());
                Behavior(ref f, act, ref health[0], ref health[1]);
                Console.WriteLine("Second Player:");
                act = Convert.ToString(Console.ReadLine());
                Behavior(ref s, act, ref health[1], ref health[0]);
            }
            if (health[0] <= 0)
                Console.WriteLine("Second Player Wins! PAKTE!");
            else if (health[1] <= 0)
                Console.WriteLine("First Player Wins! PAKTE! ");
            Console.ReadKey();
        }

        //Actions
        static void Behavior(ref string player, string do_act, ref int PH, ref int EH)
        {
            switch(do_act)
            {
                case "Health":
                    PH = PH + 10;
                    Console.WriteLine($"{player} player healed self");
                    Console.WriteLine($"First: {health[0]}hp vs Second: {health[1]}hp");
                    break;
                case "Kick":
                    EH = EH - 20;
                    Console.WriteLine($"{player} player kicked another");
                    Console.WriteLine($"First: {health[0]}hp vs Second: {health[1]}hp");
                    break;
                default:
                    Console.WriteLine($"{player} player made nothing");
                    Console.WriteLine($"First: {health[0]}hp vs Second: {health[1]}hp");
                    break;
            }
        }
    }
}
