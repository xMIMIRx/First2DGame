using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First2DGame
{
    class Objects
    {
        private readonly String icon;

        public Objects(string icon)
        {
            this.icon = icon;
        }

        public void ViewPlayer()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(icon);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
