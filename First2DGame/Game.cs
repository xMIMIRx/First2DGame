using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First2DGame
{
    class Game
    {
        private int PlayerX;
        private int PlayerY;
        private int[][] map;

        public Game(int[][] map)
        {
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
                    // Ściany
                    if (map[y][x] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("W");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    // Gracz
                    else if (map[y][x] == 2)
                    {
                        PlayerX = y;
                        PlayerY = x;
                    }
                    // Meta
                    else if (map[y][x] == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("?");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    // Płapka
                    else if (map[y][x] == 4)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkRed;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("#");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
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
                // Chodzenie
                if (key.Key == ConsoleKey.W && PlayerY > 0)
                {
                    if (PlayerCanMove(PlayerX, PlayerY - 1))
                    {
                        HidePlayer();
                        PlayerY--;
                        DrawPlayer();
                    }
                }
                if (key.Key == ConsoleKey.S)
                {
                    if (PlayerCanMove(PlayerX, PlayerY + 1))
                    {
                        HidePlayer();
                        PlayerY++;
                        DrawPlayer();
                    }
                }
                if (key.Key == ConsoleKey.A && PlayerX > 0)
                {
                    if (PlayerCanMove(PlayerX - 1, PlayerY))
                    {
                        HidePlayer();
                        PlayerX--;
                        DrawPlayer();
                    }
                }
                if (key.Key == ConsoleKey.D)
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
                    return;
                }
                // ==============
                if (map[PlayerY][PlayerX] == 3)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\n   !!! BRAWO PRZESZEDŁEŚ POZIOM !!!");
                    Thread.Sleep(2000);
                    return;
                }
                if (map[PlayerY][PlayerX] == 4)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n   !!! SKUCHA !!!");
                    Thread.Sleep(2000);
                    return;
                }
            }
        }
    }
}
