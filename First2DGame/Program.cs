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
        }
    }
}