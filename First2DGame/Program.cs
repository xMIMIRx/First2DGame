using System;
using System.Text;

namespace First2DGame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.Title = "The Game";
            Console.CursorVisible = false;
            UserInterface userInterface = new UserInterface();
            while (true)
            {
                userInterface.SelectingOptions();
            }


            /*
            string data = File.ReadAllText("Levels/level1.txt", Encoding.UTF8);

            String[] x = data.Split(";");

            int[][] result = new int[x.Length][];

            for (int i = 0; i < x.Length; i++)
            {
                String[] row = x[i].Split(",");
                result[i] = new int[row.Length];

                for (int j = 0; j < row.Length; j++)
                {
                    result[i][j] = Int32.Parse(row[j]);
                }
            }

            foreach (int[] tab in result)
            {
                foreach (int licz in tab)
                {
                    Console.Write(licz);
                }
                Console.WriteLine();
            }
            */

            /*
                        string file = "Levels/level" + 1 + ".txt";
                        var data = File.ReadAllText(file, Encoding.UTF8);
                        Console.Write(data);    
            */
        }
    }
}