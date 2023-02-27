using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First2DGame
{
    class Elements
    {
        private readonly string Text;
        private readonly ConsoleColor ForegroundColor_First;
        private readonly ConsoleColor BackgroundColor_First;
        private readonly ConsoleColor ForegroundColor_Last;
        private readonly ConsoleColor BackgroundColor_Last;

        public Elements(string Text, ConsoleColor ForegroundColor_First, ConsoleColor BackgroundColor_First, ConsoleColor ForegroundColor_Last, ConsoleColor BackgroundColor_Last)
        {
            this.Text = Text;
            this.ForegroundColor_First = ForegroundColor_First;
            this.BackgroundColor_First = BackgroundColor_First;
            this.ForegroundColor_Last = ForegroundColor_Last;
            this.BackgroundColor_Last = BackgroundColor_Last;
        }
        public Elements(string Text, ConsoleColor ForegroundColor_First, ConsoleColor ForegroundColor_Last)
        {
            this.Text = Text;
            this.ForegroundColor_First = ForegroundColor_First;
            this.BackgroundColor_First = ConsoleColor.Black;
            this.ForegroundColor_Last = ForegroundColor_Last;
            this.BackgroundColor_Last = ConsoleColor.Black;
        }
        public Elements()
        {
            this.Text = "";
        }
        public void ViewText()
        {
            Console.ForegroundColor = ForegroundColor_First;
            Console.BackgroundColor = BackgroundColor_First;
            Console.Write(Text);
            Console.ForegroundColor = ForegroundColor_Last;
            Console.BackgroundColor = BackgroundColor_Last;
        }
        public void Title()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("=======================================================================\r\n" +
                          "   /__  ___/                     //   ) )                              \r\n" +
                          "     / /  / __      ___         //         ___      _   __      ___    \r\n" +
                          "    / /  //   ) ) //___) )     //  ____  //   ) ) // ) )  ) ) //___) ) \r\n" +
                          "   / /  //   / / //           //    / / //   / / // / /  / / //        \r\n" +
                          "  / /  //   / / ((____       ((____/ / ((___( ( // / /  / / ((____     \r\n" +
                          "=======================================================================\r\n\n");

            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
