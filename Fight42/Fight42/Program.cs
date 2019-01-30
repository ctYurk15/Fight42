using System;

namespace Fight42
{
    class Program
    {
        //data of players(hp, kicks, all damage)
        public static int[] data1 = { 40, 0, 0 };
        public static int[] data2 = { 40, 0, 0 };


        //main method
        static void Main(string[] args)
        {
            Console.WriteLine("|Welcome to Fight42! Lets Start!|");
            GameCycle();
            Console.WriteLine("First player:");
            Console.WriteLine($"Total kicks: {data1[1]} Total damage: {data1[2]}");
            Console.WriteLine("Second player:");
            Console.WriteLine($"Total kicks: {data2[1]} Total damage: {data2[2]}");
            Console.ReadKey();
        }

        //game cycle, return result
        static void GameCycle()
        {
            string action = "Empty";
            if(data1[0] > 0)
            {
                Console.Write("|First Player  |: ");
                action = Console.ReadLine();
                Behavior("First", action, ref data1, ref data2);
                if(data2[0] > 0)
                {
                    Console.Write("|Second Player |: ");
                    action = Console.ReadLine();
                    Behavior("Second", action, ref data2, ref data1);
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
        static void Behavior(string player, string do_act, ref int[] PD, ref int[] ED)
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
                    if (ED[0] <= 15)
                    {
                        PD[2] = ED[0] - 15;
                        Console.WriteLine("|Footballer fatality!|");
                    }
                    else
                    {
                        PD[2] += 15;
                        Console.WriteLine($"|-15 HP|\n|{player} player kicked with foot another!|");
                    }
                    ED[0] = ED[0] - 15;
                    Console.WriteLine($"|First: {data1[0]}hp vs Second: {data2[0]}hp|");
                    break;
                //hit with hand
                case "Hand-Hit":
                    PD[1] += 1;
                    if (ED[0] <= 10)
                    {
                        PD[2] += ED[0] - 10;
                        Console.WriteLine("Boxer Fatality!");
                    }
                    else
                    {
                        PD[2] += 10;
                        Console.WriteLine($"|-10 HP|\n|{player} player kicked with hand another!|");
                    }
                    ED[0] = ED[0] - 10;
                    Console.WriteLine($"|First: {data1[0]}hp vs Second: {data2[0]}hp|");
                    break;
                //vampirizm
                case "Vampirizm":
                    PD[1] += 1;
                    if(ED[0] >= 9)
                    {
                        ED[0] = ED[0] - 9;
                        PD[2] += 9;
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
                        Console.WriteLine("|-9 HP|");
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
