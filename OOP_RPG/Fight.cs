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
            this.AddMonster("Squid", 9, 8, 20);
            this.AddMonster("Dragon", 15, 10, 50);
            this.AddMonster("Frog", 3, 2, 5);
            this.AddMonster("Troll", 10, 8, 25);
        }

        // method add new monster to the game
        public void AddMonster(string name, int strength, int defense, int hp)
        {

            this.Monsters.Add(new Monster(name, strength, defense, hp));
        }

        public void MonsterMenu()
        {


            Console.WriteLine("Please choose an option by entering a number.");
            Console.WriteLine("1. Fight last monster");
            Console.WriteLine("2. Fight second monster");
            Console.WriteLine("3. Fight first monster with less than 20 hit points");
            Console.WriteLine("4. Fight first monster with a strength of at least 11");
            Console.WriteLine("5. Fight random monster");
            var input = Console.ReadLine();
            if (input == "1")
            {
                this.Start(Monsters.Last());
            }
            else if (input == "2")
            {
                this.Start(Monsters[1]);
            }
            else if (input == "3")
            {
                this.Start(Monsters.Where(p => p.OriginalHP < 20).ToList().First());
            }
            else if (input == "4")
            {
                this.Start(Monsters.Where(p => p.Strength >= 11).ToList().First());
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

        // start the fight with first  monste in monster List
        public void Start(Monster monster)
        {

            this.monster = monster;

            Console.WriteLine("You've encountered a " + monster.Name + "! " + monster.Strength + " Strength/" + monster.Defense + " Defense/" +
            monster.CurrentHP + " HP. What will you do?");
            Console.WriteLine("1. Fight");
            var input = Console.ReadLine();
            if (input == "1")
            {
                this.HeroTurn();
            }
            else
            {
                this.game.Main();
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
            Console.WriteLine("You did " + damage + " damage!");

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
            Console.WriteLine(monster.Name + " does " + damage + " damage!");
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
            Console.WriteLine(monster.Name + " has been defeated! You win the battle!");
            game.Main();
        }


        //lose method
        public void Lose()
        {
            Console.WriteLine("You've been defeated! :( GAME OVER.");
            return;
        }

    }

}