using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IntegerToHexString
{
    class Program
    {
        public static string HexColor(string input) 
        {
            StringBuilder sb = new StringBuilder();
            uint[] values = input.Split(',').Select(UInt32.Parse).ToArray();

            if (values.Length > 3)
                return "invalid input";

            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] > 255)
                    return "invalid input";
            }

            return "#" + values[0].ToString("X2") + values[1].ToString("X2") + values[2].ToString("X2");
        }

        // Optional Bonus
        public static string Blend(List<string> list)
        {
            double r = 0;
            double g = 0;
            double b = 0;

            for (int i = 0; i < list.Count; i++)
            {
                string temp = list[i].Substring(1, 2);
                r += Convert.ToInt32(list[i].Substring(1, 2), 16);
                g += Convert.ToInt32(list[i].Substring(3, 2), 16);
                b += Convert.ToInt32(list[i].Substring(5), 16);
            }

            r = Math.Round(r / list.Count);
            g = Math.Round(g / list.Count);
            b = Math.Round(b / list.Count);
 
            return HexColor(r + ", " + g + ", " + b);
        }

        // Test
        public static void Main(string[] args)
        {
            string[] input = 
            {
                "255, 99, 71",
                "184, 134, 11",
                "189, 183, 107",
                "0, 0, 205"
            };

            List<string> blendinput1 = new List<string>
            {
                "#000000",
                "#778899"
            };

            List<string> blendinput2 = new List<string>
            {
                "#E6E6FA",
                "#FF69B4",
                "#B0C4DE"
            };

            for (int i = 0; i < input.Length; i++)
            {
                Console.WriteLine("hexcolor(" + input[i] + ") => " + HexColor(input[i]));
            }

            Console.WriteLine("blend({" + string.Join(", ", blendinput1) + "}) => " + Blend(blendinput1));
            Console.WriteLine("blend({" + string.Join(", ", blendinput2) + "}) => " + Blend(blendinput2));

            Console.ReadLine();
        }
    }
}
