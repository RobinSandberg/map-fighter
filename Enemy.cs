using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emolition_fighter
{
    class Enemy
    {
        public string Opponent { get; set; }
        public int EHealth { get; set; }
        public int EDamage { get; set; }
        public int EArmor { get; set; }
        public int EAttack { get; set; }

        public Enemy(string name)
        {

            Opponent = name;
            EHealth = 5;
            EDamage = 1;
            EArmor = 9;
            EAttack = 1;

        }
        public Enemy(string name, int health, int damage, int armor, int attack) : this(name)
        {
            EHealth = health;
            EDamage = damage;
            EArmor = armor;
            EAttack = attack;

        }
    }
}
