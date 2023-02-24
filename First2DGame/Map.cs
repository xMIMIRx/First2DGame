using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First2DGame
{
    class Map
    {
        public int PlayerX;
        public int PlayerY;
        public int[][] map;

        public Map(int[][] map)
        {
            PlayerX = 2;
            PlayerY = 2;
            this.map = map;
        }

        public void DrawMap()
        {
            for (int y = 0; y < map.Length; y++)
            {
                for (int x = 0; x < map[y].Length; x++)
                {
                    Console.CursorLeft = x;
                    Console.CursorTop = y;
                    if (map[y][x] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("#");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (map[y][x] == 4)
                    {
                        PlayerX = y;
                        PlayerY = x;
                    }

                }
            }
        }
        public bool PlayerCanMove(int x, int y)
        {
            if (map[y][x] != 1) return true;
            else return false;
        }
        public void DrawPlayer()
        {
            Console.CursorLeft = PlayerX;
            Console.CursorTop = PlayerY;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write((char)2);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void HidePlayer()
        {
            Console.CursorLeft = PlayerX;
            Console.CursorTop = PlayerY;
            Console.Write(" ");
        }
        public void LogicMap()
        {
            DrawMap();
            while (true)
            {
                Console.CursorVisible = false;
                DrawPlayer();

                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.W && PlayerY > 0)
                {
                    if (PlayerCanMove(PlayerX, PlayerY - 1))
                    {
                        HidePlayer();
                        PlayerY--;
                        DrawPlayer();
                    }
                }
                else if (key.Key == ConsoleKey.S)
                {
                    if (PlayerCanMove(PlayerX, PlayerY + 1))
                    {
                        HidePlayer();
                        PlayerY++;
                        DrawPlayer();
                    }
                }
                else if (key.Key == ConsoleKey.A && PlayerX > 0)
                {
                    if (PlayerCanMove(PlayerX - 1, PlayerY))
                    {
                        HidePlayer();
                        PlayerX--;
                        DrawPlayer();
                    }
                }
                else if (key.Key == ConsoleKey.D)
                {
                    if (PlayerCanMove(PlayerX + 1, PlayerY))
                    {
                        HidePlayer();
                        PlayerX++;
                        DrawPlayer();
                    }
                }
                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
