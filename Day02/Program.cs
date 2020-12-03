using System;
using System.Collections.Generic;
using System.Linq;

namespace Day02
{
    class Program
    {
        static void Main()
        {
            
            int i = 0;
            int area = 0;
            int length = 0;
            
            string[] lines = System.IO.File.ReadAllLines(@"C:\CodeBase\VS19\AdventOfCode2015\Day02\data.txt"); // ***** change this to the location of data.txt *****
            
            (int l, int w, int h)[] boxes = new (int, int, int)[lines.Length];

            foreach (var line in lines)
            {                 
                string[] components = line.Split('x');
                boxes[i++] = (int.Parse(components[0]), int.Parse(components[1]), int.Parse(components[2]));                
            }

            foreach (var box in boxes)
            {
                int a = box.l * box.h;
                int b = box.w * box.h;
                int c = box.l * box.w;

                int[] sideareas = { a, b, c };
                int minarea = sideareas.Min();

                area += (2*a + 2*b + 2*c + minarea);

                int[] sidelengths = { box.l, box.w, box.h};
                int maxlength = sidelengths.Max();

                int volume = box.l * box.w * box.h;

                length += (2 * box.l + 2 * box.w + 2 * box.h - 2 * maxlength + volume);

            }

            Console.WriteLine($"The required amount of paper is : {area} sq. feet ");
            Console.WriteLine($"The required length of ribbon is: {length} feet.");
        }


    }
}
