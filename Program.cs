using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emolition_fighter
{
    class Program
    {
        static void Main(string[] args)
        {
            Map map = new Map();
            map.World();
            Inventory inventory = new Inventory();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Go to Map\n2. Inventory");
                int input = GetInput();

                switch (input)
                {
                    case '1':
                        map.Play();
                        
                        break;
                    case '2':
                        inventory.Bag();
                        break;
                   
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
