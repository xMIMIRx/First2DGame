﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

namespace First2DGame
{
    class UserInterface
    {
        Loading loading = new Loading();
        public String[] menu;
        static int x = 0;

        public void DrawMenu(int x)
        {
            menu = loading.DrawFiles();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("=======================================================================\r\n" +
                          "   /__  ___/                     //   ) )                              \r\n" +
                          "     / /  / __      ___         //         ___      _   __      ___    \r\n" +
                          "    / /  //   ) ) //___) )     //  ____  //   ) ) // ) )  ) ) //___) ) \r\n" +
                          "   / /  //   / / //           //    / / //   / / // / /  / / //        \r\n" +
                          "  / /  //   / / ((____       ((____/ / ((___( ( // / /  / / ((____     \r\n" +
                          "=======================================================================\r\n\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < menu.Length; i++)
            {
                if (x >= 0 && i < menu.Length)
                {
                    if (x == i)
                    {
                        if(i == menu.Length - 1) Console.ForegroundColor = ConsoleColor.Red; 
                        else Console.ForegroundColor = ConsoleColor.Green; 

                        Console.WriteLine(" [ " + menu[i] + " ]");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        Console.WriteLine("   " + menu[i]);
                    }
                }
            }
        }
        public void SelectingOptions()
        {
            Console.Clear();
            DrawMenu(x);

            ConsoleKeyInfo key = Console.ReadKey(true);
            if ((key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow) && x > 0) x--;
            else if ((key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow) && x < menu.Length - 1) x++;
            else if (key.Key == ConsoleKey.Enter || key.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Click();
                return;
            }

            Console.Clear();
            DrawMenu(x);
        }
        public void Click()
        {
            Map map = new Map(loading.LoadMap(x + 1));
            if (x == menu.Length - 1)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Environment.Exit(0);
            }
            else
            {
                map.LogicMap();
            }
        }
    }
}
