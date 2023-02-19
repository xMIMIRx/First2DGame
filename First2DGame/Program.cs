namespace First2DGame
{
    public class Program
    {
        private static int PlayerX = 2;
        private static int PlayerY = 2;

        private static readonly int[,] map =
        {
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 0, 4, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, },
            { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, }
        };
        
        public static void DrawMap()
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                for (int x = 0; x < map.GetLength(0); x++)
                {
                    Console.CursorLeft = y;
                    Console.CursorTop = x;
                    if (map[x, y] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.Write("#");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (map[x, y] == 4)
                    {
                        PlayerX = y;
                        PlayerY = x;
                    }

                }
            }
        }

        public static bool PlayerCanMove(int x, int y)
        {
            if (map[y, x] != 1) return true;
            else return false;
        }
        public static void DrawPlayer()
        {
            Console.CursorLeft = PlayerX;
            Console.CursorTop = PlayerY;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write((char) 2);
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void HidePlayer()
        {
            Console.CursorLeft = PlayerX;
            Console.CursorTop = PlayerY;
            Console.Write(" ");
        }
        public static void Main(string[] args)
        {
            Console.Title = "title";
            DrawMap();
            while (true)
            {
                Console.CursorVisible = false;
                DrawPlayer();

                ConsoleKeyInfo key = Console.ReadKey(true);
                if (key.Key == ConsoleKey.W && PlayerY > 0)
                {
                    if (PlayerCanMove(PlayerX, PlayerY-1))
                    {
                        HidePlayer();
                        PlayerY--;
                        DrawPlayer();
                    }
                }
                else if (key.Key == ConsoleKey.S)
                {
                    if (PlayerCanMove(PlayerX, PlayerY+1))
                    {
                        HidePlayer();
                        PlayerY++;
                        DrawPlayer();
                    }
                }
                else if (key.Key == ConsoleKey.A && PlayerX > 0)
                {
                    if (PlayerCanMove(PlayerX-1, PlayerY))
                    {
                        HidePlayer();
                        PlayerX--;
                        DrawPlayer();
                    }
                }
                else if (key.Key == ConsoleKey.D)
                {
                    if (PlayerCanMove(PlayerX+1, PlayerY))
                    {
                        HidePlayer();
                        PlayerX++;
                        DrawPlayer();
                    }
                }
                if(key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}