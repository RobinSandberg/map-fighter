using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lexicon.CSharp.InfoGenerator;

namespace Emolition_fighter
{
    class Map
    {
        
        static List<int[]> holes = new List<int[]>();
        static List<int[]> chest = new List<int[]>();
        static List<int[]> enemies = new List<int[]>();
        static List<int[]> player = new List<int[]>();
        static List<Character> playerCharacters = new List<Character>();
        static List<Enemy> enemyCharacters = new List<Enemy>();
        static public Random rng = new Random();

        static private string GetPos(int y, int x)
        {
            //int[] pos = [3, 5];
            foreach (int[] pos in holes)
            {
                if (pos[0] == y && pos[1] == x) return " X ";

            }
            foreach (int[] pos in chest)
            {
                if (pos[0] == y && pos[1] == x) return " T ";
            }
            foreach (int[] pos in enemies)
            {
                if (pos[0] == y && pos[1] == x) return " E ";
            }
            for (int i = 0; i < player.Count; i++)
            {
                int[] pos = player[i];
                if (pos[0] == y && pos[1] == x) return " P" + (i + 1);
            }
            return " O ";
        }

        public void World()
        {

            string[,] map = new string[10, 15];

            for (int i = 0; i < 20; i++)
            {
                int tempY;
                int tempX;
                do
                {
                    tempY = rng.Next(0, 9);
                    tempX = rng.Next(0, 14);
                } while (GetPos(tempY, tempX) != " O ");
                holes.Add(new int[] { tempY, tempX });
            }
            for (int i = 0; i < 8; i++)
            {
                int tempY;
                int tempX;
                do
                {
                    tempY = rng.Next(2, 7);
                    tempX = rng.Next(2, 12);
                } while (GetPos(tempY, tempX) != " O ");
                chest.Add(new int[] { tempY, tempX });
            }
            for (int i = 0; i < 2; i++)
            {
                InfoGenerator names = new InfoGenerator(DateTime.Now.Millisecond);
                Gender gender = Gender.Any;
                int tempY;
                int tempX;
                do
                {
                    tempY = rng.Next(2, 7);
                    tempX = rng.Next(2, 12);
                } while (GetPos(tempY, tempX) != " O ");
                enemies.Add(new int[] { tempY, tempX });
                enemyCharacters.Add(new Enemy(names.NextFirstName(gender)));
            }

            bool select = true;
            while (select)
            {
                Console.Write("How many players 1-4?: ");
                try
                {
                    string userIn = Console.ReadLine();
                    int inputInt = Convert.ToInt32(userIn);
                    if (inputInt < 1 || inputInt > 4) throw new Exception("Too many players or no player.");
                    int players = 0;
                    for (int i = 0; i < (players = inputInt); i++)
                    {
                        int tempY;
                        int tempX;
                        do
                        {
                            tempY = rng.Next(2, 7);
                            tempX = rng.Next(2, 12);
                        } while (GetPos(tempY, tempX) != " O ");
                        player.Add(new int[] { tempY, tempX });
                        Console.WriteLine("Name your character.");
                        bool naming = true;
                        string name = Console.ReadLine();
                        while (naming)
                        {
                            if (name == "")//If no name added to string
                            {
                                Console.Write("\nEnter a name: ");
                                name = Console.ReadLine();
                                naming = true;
                            }
                            else
                            {
                                playerCharacters.Add(new Character(name));
                                naming = false;
                            }

                        }
                    }
                    select = false;
                }
                catch (FormatException)
                {
                    Console.WriteLine("Not a number try again.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            int y;
            int x;
            for (y = 0; y < 10; y++)
            {
                for (x = 0; x < 15; x++)
                {
                    map[y, x] = GetPos(y, x); // holes , chests , enemies and player.
                }
            }

            for (y = 0; y < 10; y++)
            {
                for (x = 0; x < 15; x++)
                {

                    if (map[y, x] == " O ")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (map[y, x] == " X ")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (map[y, x] == " T ")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    if (map[y, x] == " E ")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if (map[y, x] == " P1" || map[y, x] == " P2" || map[y, x] == " P3" || map[y, x] == " P4")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.Write(map[y, x]);
                }
                Console.WriteLine("\n");

            }
        }
        int y;
        int x;
        string[,] map = new string[10, 15];
        public void Play()
        {
            
            bool direction = true;

            while (direction)
            {
                for (int i = 0; i < player.Count; i++)
                {
                    Print();
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("      Movement Keys\n\n\t   W\t\t\tMenus\n\t   =\t\t\t1. Inventory\n\t North \t\t\t2. Store\n A = West     East = D\t\t3. Main menu\n\t South\n\t   =\n\t   S");
                    y = player[i][0];
                    x = player[i][1];
                    Console.SetCursorPosition(50, 20);
                    Console.WriteLine(playerCharacters[i].Player );
                    char movement = GetInput();

                    switch (movement)
                    {
                        case 'w':
                            if (player[i][0] == 0)
                            {
                            }
                            else if (GetPos(y - 1, x) == " X ")
                            {
                                
                                /* GetPos();*/ //if is "   ", hole
                            }
                            else if (GetPos(y - 1, x) == " E ")
                            {
                                player[i][0]--;
                                Fight fight = new Fight(playerCharacters[i], enemyCharacters, enemies);
                            }
                            else if (GetPos(y - 1, x) == " T ")
                            {
                               
                                player[i][0]--;
                            }
                            else
                            {
                                player[i][0]--;
                                direction = true;
                            }
                            break;

                        case 's':
                            if (player[i][0] == 9)
                            {
                            }
                            else if (GetPos(y + 1, x) == " X ")
                            {
                            }
                            else if (GetPos(y + 1, x) == " E ")
                            {
                                player[i][0]++;
                                Fight fight = new Fight(playerCharacters[i], enemyCharacters, enemies);
                            }
                            else if (GetPos(y + 1, x) == " T ")
                            {
                                player[i][0]++;
                            }
                            else
                            {
                                player[i][0]++;
                                direction = true;
                            }
                            break;

                        case 'd':
                            if (player[i][1] == 14)
                            {
                            }
                            else if (GetPos(y, x + 1) == " X ")
                            {
                            }
                            else if (GetPos(y, x + 1) == " E ")
                            {
                                player[i][1]++;
                                Fight fight = new Fight(playerCharacters[i], enemyCharacters, enemies);
                            }
                            else if (GetPos(y, x + 1) == " T ")
                            {
                                player[i][1]++;
                            }
                            else
                            {
                                player[i][1]++;
                                direction = true;
                            }
                            break;

                        case 'a':
                            if (player[i][1] == 0)
                            {
                            }
                            else if (GetPos(y, x - 1) == " X ")
                            {
                            }
                            else if (GetPos(y, x - 1) == " E ")
                            {
                                player[i][1]--;
                                Fight fight = new Fight(playerCharacters[i], enemyCharacters, enemies);
                            }
                            else if (GetPos(y, x - 1) == " T ")
                            {
                                player[i][1]--;
                            }
                            else
                            {
                                player[i][1]--;
                                direction = true;
                            }
                            break;

                        case '1':
                            
                            break;

                        case '2':
                            
                            break;

                        case '3':

                            direction = false;
                            break;
                    }
                }
                Console.Clear();
                Enemymovement();
                Print();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("      Movement Keys\n\n\t   W\t\t\tMenus\n\t   =\t\t\t1. Inventory\n\t North \t\t\t2. Store\n A = West     East = D\t\t3. Main menu\n\t South\n\t   =\n\t   S");
            }
        }
        static void Print()
        {
            Console.Clear();
            int y;
            int x;
            string[,] map = new string[10, 15];
            for (y = 0; y < 10; y++)
            {
                for (x = 0; x < 15; x++)
                {

                    map[y, x] = GetPos(y, x); // holes , chests , enemies and player.

                }
            }
            for (y = 0; y < 10; y++)
            {
                for (x = 0; x < 15; x++)
                {

                    if (map[y, x] == " O ")
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    if (map[y, x] == " X ")
                    {
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    if (map[y, x] == " T ")
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                    }
                    if (map[y, x] == " E ")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    if (map[y, x] == " P1" || map[y, x] == " P2" || map[y, x] == " P3" || map[y, x] == " P4")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }

                    Console.Write(map[y, x]);
                }
                Console.WriteLine("\n");
            }
        }
        static void Enemymovement()
        {
            bool Emove = enemies.Count > 0;

            while (Emove)
            {
                for (int i = 0; i < enemies.Count; i++)
                {
                    int y = enemies[i][0];
                    int x = enemies[i][1];
                    int input = rng.Next(1, 5);


                    switch (input)
                    {
                        case 1:
                            if (enemies[i][0] == 0)
                            {
                            }
                            else if (GetPos(y - 1, x) == " X ")
                            {
                            }
                            else if (GetPos(y - 1, x) == " E ")
                            {
                            }
                            else if (GetPos(y - 1, x) == " P ")
                            {
                                enemies[i][0]--;
                                Fight fight = new Fight(playerCharacters[i], enemyCharacters, enemies);
                            }
                            else
                            {
                                enemies[i][0]--;
                                Emove = false;
                            }
                            break;
                        case 2:
                            if (enemies[i][0] == 9)
                            {
                            }
                            else if (GetPos(y + 1, x) == " X ")
                            {
                            }
                            else if (GetPos(y + 1, x) == " E ")
                            {
                            }
                            else if (GetPos(y + 1, x) == " P ")
                            {
                                enemies[i][0]++;
                                Fight fight = new Fight(playerCharacters[i], enemyCharacters, enemies);
                            }
                            else
                            {
                                enemies[i][0]++;
                                Emove = false;
                            }
                            break;
                        case 3:
                            if (enemies[i][1] == 14)
                            {
                            }
                            else if (GetPos(y, x + 1) == " X ")
                            {
                            }
                            else if (GetPos(y, x + 1) == " E ")
                            {
                            }
                            else if (GetPos(y, x + 1) == " P ")
                            {
                                enemies[i][1]++;
                                Fight fight = new Fight(playerCharacters[i], enemyCharacters, enemies);
                            }
                            else
                            {
                                enemies[i][1]++;
                                Emove = false;
                            }
                            break;
                        case 4:
                            if (enemies[i][1] == 0)
                            {
                            }
                            else if (GetPos(y, x - 1) == " X ")
                            {
                            }
                            else if (GetPos(y, x - 1) == " E ")
                            {
                            }
                            else if (GetPos(y, x - 1) == " P ")
                            {
                                enemies[i][1]--;
                                Fight fight = new Fight(playerCharacters[i], enemyCharacters, enemies);
                            }
                            else
                            {
                                enemies[i][1]--;
                                Emove = false;
                            }
                            break;
                    }
                }
            }
        }

        static char GetInput()
        {
            ConsoleKeyInfo userIn = Console.ReadKey(true);
            return userIn.KeyChar;
        }
    }
}

