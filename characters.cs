using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emolition_fighter
{
    class Character
    {
        public string Player { get; set; }
        public int Gold = 0;// Starting number for the gold and score.
        public int score = 0;
        // Random and set numbers added to your stats and the Opponents stats.
        public int PHealth { get; set; }
        public int PDamage { get; set; }
        public int PArmor { get; set; }
        public int PAttack { get; set; }
        //public int y;
        //public int x;
       
        public Character(string name) // Naming your character here.
        {

            Player = name;
            PHealth = 10;
            PDamage = 2;
            PArmor = 11;
            PAttack = 2;
        }
        public Character(string name, int health, int damage, int armor, int attack) : this(name)
        {
            PHealth = health;
            PDamage = damage;
            PArmor = armor;
            PAttack = attack;

        }
    }
}
