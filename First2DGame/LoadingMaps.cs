using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First2DGame
{
    class LoadingMaps
    {
        public int[][] loadMap(int level)
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
    }
}
