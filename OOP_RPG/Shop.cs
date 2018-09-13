using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    internal class Shop : IShop
    {

        public List<Weapon> ShopWeapons { get; set; }
        public List<Armor> ShopArmor { get; set; }
        public List<Potion> ShopPotion { get; set; }

        public Shop()
        {
            ShopWeapons = new List<Weapon>();
            ShopArmor = new List<Armor>();
            ShopPotion = new List<Potion>();
            ShopWeapons.Add(new Weapon("Sword", 10, 2, 3));
            ShopWeapons.Add(new Weapon("Axe", 12, 3, 4));
            ShopWeapons.Add(new Weapon("Longsword", 20, 5, 7));
            ShopArmor.Add(new Armor("Wooden Armor", 10, 2, 3));
            ShopArmor.Add(new Armor("Metal Armor", 20, 5, 7));
            ShopPotion.Add(new Potion("Healing Potion", 10, 3, 5));
        }

     
     

        internal void DisplayWeapon(Hero hero)
        {
            Console.WriteLine();
            for (var i = 0; i < this.ShopWeapons.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {this.ShopWeapons[i].Name}. Strength: {this.ShopWeapons[i].Strength}. Cost: {this.ShopWeapons[i].OriginalValue} gold.");
            }
            //check for correct input
            bool result = Int32.TryParse(Console.ReadLine(),out int input);
            if (result == false || input > ShopWeapons.Count)
            {
                Console.WriteLine();
                Console.WriteLine("Wrong item!");
                return;
            }
            // if input correct call sell function with current item
            this.SellItemToHero(hero,ShopWeapons[input-1], "1");
        }

      

        internal void DisplayArmor(Hero hero)
        {
            Console.WriteLine();
            for (var i = 0; i < ShopArmor.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ShopArmor[i].Name}. Defense: {ShopArmor[i].Defense}. Cost: {ShopArmor[i].OriginalValue} gold.");
            }
            //check for correct input
            bool result = Int32.TryParse(Console.ReadLine(), out int input);
            if (result == false || input > ShopArmor.Count)
            {
                Console.WriteLine();
                Console.WriteLine("Wrong item!");
                return;
            }
            // if input correct call sell function with current item
            this.SellItemToHero(hero, ShopArmor[input - 1], "2");
        }

        internal void DisplayPotions(Hero hero)
        {
            Console.WriteLine();
            for (var i = 0; i < ShopPotion.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ShopPotion[i].Name}. Defense: {ShopPotion[i].HP}. Cost: {ShopPotion[i].OriginalValue} gold.");
            }
            //check for correct input
            bool result = Int32.TryParse(Console.ReadLine(), out int input);
            if (result == false || input > ShopPotion.Count)
            {
                Console.WriteLine();
                Console.WriteLine("Wrong item!");
                return;
            }
            // if input correct call sell function with current item
            this.SellItemToHero(hero, ShopPotion[input - 1], "3");
        }

        internal void BuyItemFromHero()
        {

        }

        internal void SellItemToHero(Hero hero, IItem item, string itemType)
        {

            // itemType specify is it a weapon, armor or potion. and comes from user input in menu:
            //1 - weapons
            //2 - armor
            //3 - potions
            if (hero.Gold < item.OriginalValue)
            {
                Console.WriteLine();
                Console.WriteLine($"Not enogh money. Sorry! Bye!");
                return;
            }
            hero.Gold -= item.OriginalValue;
            if (itemType == "1")
            {
                hero.WeaponsBag.Add((Weapon)item);
            }
            if (itemType == "2")
            {
                hero.ArmorsBag.Add((Armor)item);
            }
            if (itemType == "3")
            {
                hero.PotionBag.Add((Potion)item);
            }
            Console.WriteLine();
            
            Console.Write($"Great! You just bought an ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(item.Name);
            Console.ResetColor();
            Console.Write(" !!!");

            Console.WriteLine($"Come back any time!");
            return;
        }
    }


    public interface IShop
    {
        List<Weapon> ShopWeapons { get; set; }
        List<Armor> ShopArmor { get; set; }
        List<Potion> ShopPotion { get; set; }
    }
}
