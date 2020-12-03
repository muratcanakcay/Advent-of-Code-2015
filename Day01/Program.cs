using System;
using System.Collections.Generic;
using System.Linq;

namespace Day01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"C:\CodeBase\VS19\AdventOfCode2015\Day01\data.txt"); // ***** change this to the location of data.txt *****

            //foreach (var line in lines) Console.WriteLine(line);            

            int floor = 0;
            int pos = 0;
            int finalpos = 0;
            bool found = false;
            
            
            foreach (var line in lines)
            {
                foreach (char ch in line)
                {
                    pos++;

                    floor += (ch == '(') ? 1 : -1;
                    
                    if (floor == -1 && !found)
                    {
                        finalpos = pos;
                        found = true;
                    }
                }
                
            }            
           
            Console.WriteLine($"The floor to go to is: {floor}  Reaches -1 at position: {finalpos}");
        }

        
    }
}
