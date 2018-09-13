using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Game
    {
        public Hero hero { get; set; }
        internal Shop shop { get;  set; }

        public Game() {
            this.hero = new Hero();
            this.shop = new Shop();
        }
            
        public void Start() {
            Console.WriteLine("Welcome hero!");
            Console.WriteLine("Please enter your name:");
            this.hero.Name = Console.ReadLine();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Hello " + hero.Name);
            Console.ResetColor();
            Console.WriteLine();
            this.Main();
        }

        public void Main() {
    


            Console.WriteLine("Please choose an option by entering a number.");
            Console.WriteLine("1. View Stats");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. Fight Monster");
            Console.WriteLine("4. Go to shop");
            var input = Console.ReadLine();
            if (input == "1") {
                this.Stats();
            }
            else if (input == "2") {
                this.Inventory();
            }
            else if (input == "3") {
                this.Fight();
            }
            else if (input == "4")
            {
                this.DisplayShopMenu();
            }
            else {
                return;
            }
        }

        private void DisplayShopMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("***Welcome to Dwarf's shop***");
            Console.ResetColor();
            Console.WriteLine("1. Buy items");
            Console.WriteLine("2. Sell items");
            Console.WriteLine("3. Back");

            var input = Console.ReadLine();
            if (input == "1")
            {
                this.DisplayShopItemsForSell();
            }
            else if (input == "2")
            {
                this.DisplayHeroInventoryToSell();
            }
            else if (input == "3")
            {
                this.Main();
            }

            else
            {
                this.Main();
            }
        }

        private void DisplayHeroInventoryToSell()
        {
            throw new NotImplementedException();
        }

        private void DisplayShopItemsForSell()
        {
            Console.WriteLine();
            Console.WriteLine("1. Show me armor list");
            Console.WriteLine("2. Show me weapon list");
            Console.WriteLine("3. Show me potion list");
            var input = Console.ReadLine();
            if (input == "1")
            {
                shop.DisplayArmor(hero);
                this.Main();
            }
            else if (input == "2")
            {
                shop.DisplayWeapon(hero);
                this.Main();
            }
            else if (input == "3")
            {
                shop.DisplayPotions(hero);
                this.Main();
            }
         
            else
            {
                this.Main();
            }

        }

        public void Stats() {
            hero.ShowStats();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            this.Main();
        }
        
        public void Inventory(){
            hero.ShowInventory();
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            this.Main();
        }
        
        public void Fight(){
            var fight = new Fight(this.hero, this);
            fight.MonsterMenu();
        }

       
        

    }
}

