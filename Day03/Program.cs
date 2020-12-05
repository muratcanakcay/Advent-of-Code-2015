using System;
using System.Collections.Generic;
using System.Linq;

namespace Day03
{
    class Program
    {
        static void Main(string[] args)
        {
            bool part2 = true;   // makes this false to get part 1's answer
            string turn = "santa";

            string[] lines = System.IO.File.ReadAllLines(@"C:\CodeBase\VS19\AdventOfCode2015\Day03\data.txt"); // ***** change this to the location of data.txt *****
            Dictionary<(int, int), int> data = new Dictionary<(int, int), int>();
                       
            (int x, int y) house1 = (0, 0); // houses visited by santa 
            (int x, int y) house2 = (0, 0); // houses visited by robosanta
            
            data.Add(house1, 1);            // add starting house to dictionary
            
            foreach (var line in lines)
            {
                for (int i = 0; i < line.Length; i++)
                {
                    if (turn == "santa")  // santa moves
                    {
                        switch (line[i])
                        {
                            case 'v':
                                house1.y++; break;
                            case '^':
                                house1.y--; break;
                            case '<':
                                house1.x--; break;
                            case '>':
                                house1.x++; break;
                        }

                        if (!data.ContainsKey(house1)) data.Add(house1, 1);  // first visit to a house
                        else data[house1]++;                                 // house has been visited before 

                        if (part2) turn = "robosanta";
                        continue;
                    }

                    if (part2 && turn == "robosanta")  // in part 2 robosanta moves
                    {
                        switch (line[i])
                        {
                            case 'v':
                                house2.y++; break;
                            case '^':
                                house2.y--; break;
                            case '<':
                                house2.x--; break;
                            case '>':
                                house2.x++; break;
                        }

                        if (!data.ContainsKey(house2)) data.Add(house2, 1);  // first visit to a house
                        else data[house2]++;                                 // house has been visited before 

                        turn = "santa";
                        continue;
                    }
                }   
            }

            int count = 0;

            foreach (var (h, p) in data)
            {                
                if (data[h] >= 1) count++;    // count houses that got at least one present
            }

            Console.WriteLine($"Houses with more than 1 visit: {count}.");
        }
    }
}
