using System;
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
            Elements title = new Elements();
            title.Title();
            for (int i = 0; i < menu.Length; i++)
            {
                if (x >= 0 && i < menu.Length)
                {
                    if (x == i)
                    {
                        if (i == menu.Length - 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\n [ EXIT ]");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine(" [ Poziom " + (i + 1) + " ]");
                        }

                        Console.ForegroundColor = ConsoleColor.Cyan;
                    }
                    else
                    {
                        if (i == menu.Length - 1) Console.WriteLine("\n   EXIT ");
                        else Console.WriteLine("   Poziom " + (i + 1));
                    }
                }
            }
            Elements footer = new Elements("\n=======================================================================", ConsoleColor.Yellow, ConsoleColor.White);
            footer.ViewText();
        }
        public void SelectingOptions()
        {
            Console.Clear();
            DrawMenu(x);

            ConsoleKeyInfo key = Console.ReadKey(true);
            if ((key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow) && x > 0) x--;
            else if ((key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow) && x < menu.Length - 1) x++;
            else if (key.Key == ConsoleKey.Enter)
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
            if (x == menu.Length - 1)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Environment.Exit(0);
            }
            else
            {
                if (loading.LoadMap(x + 1) == null)
                {
                    Elements errorMap = new Elements("\n\n\n    *PLIK MAPY JEST USZKODZONY*\n\n     *POZIOM " + (x+1) + " ZOSTAŁ USUNIĘTY*\n\n        *PROSIMY O RESTART*", ConsoleColor.Red, ConsoleColor.Black);
                    File.Delete(loading.DrawFiles()[x]);
                    errorMap.ViewText();
                    Environment.Exit(0);
                }
                else
                {
                    Game map = new Game(loading.LoadMap(x + 1));
                    map.LogicMap();
                }
            }
        }
    }
}
