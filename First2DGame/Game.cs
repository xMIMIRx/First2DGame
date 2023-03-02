using ClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First2DGame
{
    public class Game
    {
        public int PlayerX;
        public int PlayerY;
        public int[][] map;

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
                        Elements wall = new Elements("W", ConsoleColor.Blue, ConsoleColor.Blue, ConsoleColor.White, ConsoleColor.Black);
                        wall.ViewText();
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
                        Elements meta = new Elements("?", ConsoleColor.Green, ConsoleColor.White);
                        meta.ViewText();
                    }
                    // Pułapka
                    else if (map[y][x] == 4)
                    {
                        Elements trap = new Elements("#", ConsoleColor.Red, ConsoleColor.DarkRed, ConsoleColor.White, ConsoleColor.Black);
                        trap.ViewText();
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
            Elements player = new Elements("☻", ConsoleColor.Yellow, ConsoleColor.White);
            player.ViewText();
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
                if (map[PlayerY][PlayerX] == 3)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\n   !!! BRAWO PRZESZEDŁEŚ POZIOM !!!");
                    Thread.Sleep(700);
                    return;
                }
                if (map[PlayerY][PlayerX] == 4)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\n   !!! SKUCHA !!!");
                    Thread.Sleep(700);
                    return;
                }
            }
        }
    }
}
