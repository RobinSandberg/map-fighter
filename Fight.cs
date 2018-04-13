using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Emolition_fighter
{
    class Fight
    {
        public Fight(Character player, List<Enemy> enemyCharacters, List<int[]> enemies)
        {
            Random random = new Random(); // The dice rolled for combat
            int pD6;
            int eD6;
            int gold = player.Gold;// Saving the gold in new score command.
            int score = player.score;
            Console.WriteLine($"Opponents : {enemyCharacters[0].Opponent}\nStats = Health: {enemyCharacters[0].EHealth} Damage: {enemyCharacters[0].EDamage}");
            //foreach (var round in rounds)//stat incase per round played for opponent
            //{
            //    opponent.EHealth += 5;
            //    opponent.EDamage += 1;
            //    opponent.EStrenght += 1;
            //}
            int ehealth = enemyCharacters[0].EHealth; // Saving the health to new health command.
            int phealth = player.PHealth; 
            Console.WriteLine("\nPush any key to start battle");
            Console.ReadKey(true);
            Console.Clear();

            while (phealth > 0 && ehealth > 0) // Loop to 1 fighter get 0 or below health
            {
                pD6 = random.Next(1, 21); //The combat dice
                eD6 = random.Next(1, 21);
                int proll = pD6 + player.PAttack; //The Dice + strenght determinal who strike first.
                int eroll = eD6 + enemyCharacters[0].EAttack;
                if (proll > enemyCharacters[0].EArmor)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n{player.Player} rolled the D6: {pD6} = {proll} {enemyCharacters[0].Opponent} rolled the D6: {eD6} = {eroll}");
                    ehealth -= player.PDamage;
                    Console.WriteLine($"\n{player.Player} dealt {player.PDamage} damage to {enemyCharacters[0].Opponent}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                if (eroll > player.PArmor)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"\n{enemyCharacters[0].Opponent} rolled the D6: {eD6} = {eroll} {player.Player} rolled the D6: {pD6} = {proll}");
                    phealth -= enemyCharacters[0].EDamage;
                    Console.WriteLine($"\n{enemyCharacters[0].Opponent} dealt {enemyCharacters[0].EDamage} damage to {player.Player}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else if (proll < enemyCharacters[0].EArmor && eroll < player.PArmor)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"{player.Player} Weapon clash into {enemyCharacters[0].Opponent} weapon no damage dealt.\nThe weapons take damage both lose 1 damage.");
                    player.PDamage -= 0;
                    enemyCharacters[0].EDamage -= 0;
                    Console.ForegroundColor = ConsoleColor.White;

                }
                Console.WriteLine($"\nChampion : {player.Player}\nStats = Health: {phealth} Damage: {player.PDamage}");
                Console.WriteLine($"\nOpponents : {enemyCharacters[0].Opponent}\nStats = Health: {ehealth} Damage: {enemyCharacters[0].EDamage}");
                Console.WriteLine("\nPush any key to continue fighting");
                Console.ReadKey(true);
                Console.Clear();
            }
            if (ehealth <= 0)//If Opponent get to 0 health.
            {
                Console.WriteLine($"\nWinner is {player.Player}.");
                player.PHealth = phealth; // Updating the new health back to original command.
                //rounds.Add($"\nChampion {player.Player} fought and won over {opponent.Opponent}.");
                player.Gold = gold + 1;// Adding 1 point to the score.
                player.score = score + 1;
                enemyCharacters.Remove(enemyCharacters[0]);
                enemies.Remove(enemies[0]);
               /* Reward(character); */// Random reward pulled from reward table below.
            }
            if (phealth <= 0) // If player reach 0 health.
            {
                Console.WriteLine($"\nYou lost to {enemyCharacters[0].Opponent} that has health {ehealth} left\nPush any key to see final statistic.");
                enemyCharacters[0].EHealth = ehealth;
                player.PHealth = phealth;
                //rounds.Add($"\nOpponent {opponent.Opponent} fought and won over {player.Player}.");
                Console.ReadKey();
                Console.Clear();
            }


        }
    }
}
