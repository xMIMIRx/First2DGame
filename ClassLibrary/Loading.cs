using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Loading
    {
        public int[][] LoadMap(int level)
        {
            string data = File.ReadAllText("Levels/level" + level + ".txt", Encoding.UTF8);

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
            return result;
        }
        public string[] DrawFiles()
        {
            string[] files = System.IO.Directory.GetFiles("Levels/");
            string[] result = new string[files.Length + 1];
            for(int i = 0; i < result.Length; i++)
            {
                if(i == files.Length)
                {
                    result[i] = "Exit";
                }
                else
                {
                    result[i] = files[i];
                }
            }
            return result;
        }
    }
}
