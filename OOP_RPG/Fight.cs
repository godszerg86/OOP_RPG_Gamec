using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Fight
    {

        //list of monsters
        List<Monster> Monsters { get; set; }

        //class properties
        public Game game { get; set; }
        public Hero hero { get; set; }
        public Monster monster { get; set; }

        // class constructor accept hero and game class
        public Fight(Hero hero, Game game)
        {
            this.Monsters = new List<Monster>();
            this.hero = hero;
            this.game = game;
            this.AddMonster("Squid", 9, 8, 20, 13);
            this.AddMonster("Dragon", 15, 10, 50, 15);
            this.AddMonster("Frog", 3, 2, 5, 4);
            this.AddMonster("Troll", 10, 8, 25, 7);
        }

        // method add new monster to the game
        public void AddMonster(string name, int strength, int defense, int hp, int speed)
        {

            this.Monsters.Add(new Monster(name, strength, defense, hp, speed));
        }

        public void MonsterMenu()
        {


            Console.WriteLine("Please choose an option by entering a number.");
            Console.WriteLine("0. Show me all monsters!");
            Console.WriteLine("1. Fight last monster");
            Console.WriteLine("2. Fight second monster");
            Console.WriteLine("3. Fight first monster with less than 20 hit points");
            Console.WriteLine("4. Fight first monster with a strength of at least 11");
            Console.WriteLine("5. Fight random monster");
            var input = Console.ReadLine();
            if (!Monsters.Any()) //if list is empty return to main menu
            {
                Console.WriteLine();
                Console.WriteLine("No monster to fight");
                Console.WriteLine();
                game.Main();
            }
            else
            {
                if (input == "0")
                {
                    ShowMonsterList();
                }
                if (input == "1")
                {
                    this.Start(Monsters.LastOrDefault());

                }
                else if (input == "2")
                {

                    this.Start(Monsters.ElementAtOrDefault(1));
                }
                else if (input == "3")
                {
                    this.Start(Monsters.Where(p => p.OriginalHP < 20).ToList().FirstOrDefault());
                }
                else if (input == "4")
                {
                    this.Start(Monsters.Where(p => p.Strength >= 11).ToList().FirstOrDefault());
                }
                else if (input == "5")
                {
                    var randmonNumber = new Random();

                    this.Start(Monsters[randmonNumber.Next(Monsters.Count)]);
                }
                else
                {
                    return;
                }
            }

        }

        //private void ShowMonsterList()
        //{
        //    throw new NotImplementedException();
        //}

        // start the fight with first  monste in monster List
        public void Start(Monster monster)
        {
            if (monster == null)
            {
                Console.WriteLine();
                Console.WriteLine("No monster to fight");
                Console.WriteLine();
                game.Main();
            }
            this.monster = monster;
            Console.WriteLine();
            Console.WriteLine("You've encountered a " + monster.Name + "! " + monster.Strength + " Strength/" + monster.Defense + " Defense/" +
            monster.CurrentHP + " HP " + monster.Speed + "/Speed. He has a loot of " + monster.Gold + " gold. What will you do?");
            Console.WriteLine("1. Fight");
            Console.WriteLine("2. Use potion");
            Console.WriteLine("3. Escape monster.");
            var input = Console.ReadLine();
            if (input == "1")
            {
                this.HeroTurn();
            }
            else if (input == "2")
            {
                hero.DrinkPotion();
                this.Start(monster);
            }
            else if (input == "3")
            {
                this.TryEscape();

            }
            else
            {
                this.Start(monster);
            }
        }

        private void TryEscape()
        {
            if (hero.Speed > monster.Speed)
            {
                Console.WriteLine();
                Console.WriteLine($"You Succesfuly escaped {monster.Name}.");
                Console.WriteLine();
                this.game.Main();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"{monster.Name} is faster then you. You cannot escape.");
                Console.WriteLine();
                this.Start(monster);

            }
        }

        // hero tun method
        public void HeroTurn()
        {
            var compare = hero.Strength - monster.Defense;
            int damage;

            if (compare <= 0)
            {
                damage = 1;
                monster.CurrentHP -= damage;
            }
            else
            {
                damage = compare;
                monster.CurrentHP -= damage;
            }
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("You did " + damage + " damage!");
            Console.WriteLine(monster.CurrentHP > 0 ? $"{monster.Name} HP now is {monster.CurrentHP}":"");
            Console.ResetColor();
            Console.WriteLine();
            if (monster.CurrentHP <= 0)
            {
                this.Win();
            }
            else
            {
                this.MonsterTurn();
            }

        }


        // monster turn method
        public void MonsterTurn()
        {
            int damage;
            var compare = monster.Strength - hero.Defense;
            if (compare <= 0)
            {
                damage = 1;
                hero.CurrentHP -= damage;
            }
            else
            {
                damage = compare;
                hero.CurrentHP -= damage;
            }
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(monster.Name + " does " + damage + " damage!");
            Console.WriteLine($"You HP now is {hero.CurrentHP}");
            Console.WriteLine();
            Console.ResetColor();
            Console.WriteLine();
            if (hero.CurrentHP <= 0)
            {
                this.Lose();
            }
            else
            {
                this.Start(monster);
            }
        }


        // win method
        public void Win()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("*********VICTORY********");
            Console.WriteLine(monster.Name + " has been defeated! You win the battle!");
            Console.WriteLine("You collected " + monster.Gold + " gold!");
            Console.ResetColor();
            Console.WriteLine();
            hero.AddGold(monster.Gold);
            game.Main();
        }


        //lose method
        public void Lose()
        {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            return;
        }

        private void ShowMonsterList()
        {
            Console.WriteLine();
            Console.WriteLine("Here is monster list. Pick one to fight.");
            foreach (var monster in Monsters)
            {
                Console.WriteLine($"{monster.Name} with HP: {monster.OriginalHP}, STR: {monster.Strength}, DEF: {monster.Defense} and gold loot of {monster.Gold}");
                Console.WriteLine("Do you want to fight this monster?");
                Console.WriteLine("Press [F] to fight or any key for next monster");
                var input = Console.ReadLine();
                if (input == "F" || input == "f")
                {
                    this.Start(monster);
                    return;
                }

            }

            game.Main();

        }
    }

}