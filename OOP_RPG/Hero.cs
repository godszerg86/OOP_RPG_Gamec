using System;
using System.Collections.Generic;
using System.Linq;

namespace OOP_RPG
{
    public class Hero
    {
        /*This is a Constructor.
        When we create a new object from our Hero class, the instance of this class, our hero, has:
        an empty List that has to contain instances of the Armor class,
        an empty List that has to contain instance of the Weapon class,
        stats of the "int" data type, including an intial strength and defense,
        original hitpoints that are going to be the same as the current hitpoints.
        */
        public Hero()
        {
            this.ArmorsBag = new List<Armor>();
            this.WeaponsBag = new List<Weapon>();
            this.PotionBag = new List<Potion>();
            this.Strength = 10;
            this.Defense = 10;
            this.OriginalHP = 30;
            this.CurrentHP = 30;
            this.Gold = 100;
        }

        // These are the Properties of our Class.
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public int Gold { get; set; }

        public List<Armor> ArmorsBag { get; set; }
        public List<Weapon> WeaponsBag { get; set; }

        internal void ShowEquipmentMenu()
        {
            Console.WriteLine();
            Console.WriteLine("1. Show armor to equip.");
            Console.WriteLine("2. Show weapons to equip.");
            var input = Console.ReadLine();
            if (input == "1")
            {
                this.ShowArmorInventory();
            }
            else if (input == "2")
            {
                this.ShowWeaponInventory();
            }
        }

        private void ShowWeaponInventory()
        {
            if (EquippedWeapon != null)
            {

                Console.WriteLine("***[EQUIPED WEAPON]***");
                Console.WriteLine($"{this.EquippedWeapon.Name} | strength: {this.EquippedWeapon.Strength}");
                Console.WriteLine();
            }
            if (this.WeaponsBag.Any())
            {

                Console.WriteLine();
                int iterator = 1;
                foreach (Weapon item in WeaponsBag)
                {
                    Console.WriteLine($"{iterator}. {item.Name} with strength of {item.Strength}.");
                    iterator++;
                };
                Console.WriteLine("Pick item to equip");
                bool result = Int32.TryParse(Console.ReadLine(), out int input);
                if (result == false || input > iterator - 1 || input == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Wrong item!");
                    return;
                }
                this.EquipNewWeapon(WeaponsBag[input - 1]);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You bag is empty.");
                Console.WriteLine();
            }
        }

        internal void SellEquipedItems()
        {
            if (this.EquippedArmor != null || this.EquippedWeapon != null)
            {

                Console.WriteLine();
                Console.WriteLine("Pick equiped items to sell");

                Console.WriteLine(this.EquippedArmor != null ? $"1. {this.EquippedArmor.Name} for {this.EquippedArmor.ResellValue} gold." : "");
                Console.WriteLine(this.EquippedWeapon != null ? $"2. {this.EquippedWeapon.Name} for {this.EquippedWeapon.ResellValue} gold." : "");
                var input = Console.ReadLine();
                if (input == "1" && this.EquippedArmor != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{this.EquippedArmor.Name} was sold for {this.EquippedArmor.ResellValue} gold.");
                    this.Gold += this.EquippedArmor.ResellValue;
                    this.EquippedArmor = null;
                }
                else if (input == "2" && this.EquippedWeapon != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"{this.EquippedWeapon.Name} was sold for {this.EquippedWeapon.ResellValue} gold.");
                    this.Gold += this.EquippedWeapon.ResellValue;
                    this.EquippedWeapon = null;
                }
                else
                {
                    return;
                }
            }
            else
            {
                Console.WriteLine("Nothing equiped");
            }
        }

        private void EquipNewWeapon(Weapon weapon)
        {
            if (this.EquippedWeapon == null)
            {
                this.EquippedWeapon = weapon;
                this.Strength += weapon.Strength;
                this.WeaponsBag.Remove(weapon);
                Console.WriteLine();
                Console.WriteLine($"You equiped  {weapon.Name} !!!");
                Console.WriteLine();
                return;
            }
            if (this.EquippedWeapon.Equals(weapon))
            {
                Console.WriteLine();
                Console.WriteLine($"You have already {weapon.Name} equiped.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine($"You took of  {EquippedWeapon.Name} and equiped {weapon.Name} ");
            this.Strength -= this.EquippedWeapon.Strength;
            this.Strength += weapon.Strength;
            this.WeaponsBag.Remove(weapon);
            this.WeaponsBag.Add(EquippedWeapon);
            this.EquippedWeapon = weapon;
            return;
        }

        private void ShowArmorInventory()
        {
            if (EquippedArmor != null)
            {
                Console.WriteLine("***[EQUIPED ARMOR]***");
                Console.WriteLine($"{this.EquippedArmor.Name} | defence: {this.EquippedArmor.Defense}");
                Console.WriteLine();
            }
            if (this.ArmorsBag.Any())
            {

                Console.WriteLine();
                int iterator = 1;
                foreach (Armor item in ArmorsBag)
                {
                    Console.WriteLine($"{iterator}. {item.Name} with defense of {item.Defense}.");
                    iterator++;
                };
                Console.WriteLine("Pick item to equip");
                bool result = Int32.TryParse(Console.ReadLine(), out int input);
                if (result == false || input > iterator - 1 || input == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Wrong item!");
                    return;
                }
                this.EquipNewArmor(ArmorsBag[input - 1]);
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("You bag is empty.");
                Console.WriteLine();

            }

        }

        private void EquipNewArmor(Armor armor)
        {
            if (this.EquippedArmor == null)
            {
                this.EquippedArmor = armor;
                this.Defense += armor.Defense;
                this.ArmorsBag.Remove(armor);
                Console.WriteLine();
                Console.WriteLine($"You equiped  {armor.Name} !!!");
                Console.WriteLine();
                return;
            }
            if (this.EquippedArmor.Equals(armor))
            {
                Console.WriteLine();
                Console.WriteLine($"You have already {armor.Name} equiped.");
                Console.WriteLine();
                return;
            }

            Console.WriteLine($"You took of  {EquippedArmor.Name} and equiped {armor.Name}");
            this.Defense -= this.EquippedArmor.Defense;
            this.Defense += armor.Defense;
            this.ArmorsBag.Remove(armor);
            this.ArmorsBag.Add(EquippedArmor);
            this.EquippedArmor = armor;
            return;

        }

        public List<Potion> PotionBag { get; internal set; }

        //These are the Methods of our Class.
        public void ShowStats()
        {
            Console.WriteLine("*****" + this.Name + "*****");
            Console.WriteLine("Strength: " + this.Strength);
            Console.WriteLine("Defense: " + this.Defense);
            Console.WriteLine("Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);
        }

        public void ShowInventory()
        {
            if (EquippedArmor != null)
            {
                Console.WriteLine();
                Console.WriteLine("***[EQUIPED ARMOR]***");
                Console.WriteLine($"{this.EquippedArmor.Name} | defence: {this.EquippedArmor.Defense}");
                Console.WriteLine();
            }
            if (EquippedWeapon != null)
            {
                Console.WriteLine("***[EQUIPED WEAPON]***");
                Console.WriteLine($"{this.EquippedWeapon.Name} | strength: {this.EquippedWeapon.Strength}");
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("*****  INVENTORY ******");
            Console.WriteLine();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Weapons: ");
            Console.ResetColor();
            foreach (var w in this.WeaponsBag)
            {
                Console.WriteLine(w.Name + " of " + w.Strength + " Strength");

            }
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Armor: ");
            Console.ResetColor();
            foreach (var a in this.ArmorsBag)
            {
                Console.WriteLine(a.Name + " of " + a.Defense + " Defense");

            }

            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Potions: ");
            Console.ResetColor();
            foreach (var a in this.PotionBag)
            {
                Console.WriteLine(a.Name + " of " + a.HP + " HP");
            }
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Gold: " + this.Gold);
            Console.ResetColor();




        }





        internal void AddGold(int gold)
        {
            this.Gold += gold;
        }

        public void DisplayHeroInventoryToSell(Shop shop, Hero hero)
        {
            if (this.ArmorsBag.Any() || this.WeaponsBag.Any() || this.PotionBag.Any())
            {

                Console.WriteLine();
                Console.WriteLine("Here is hero's inventory. Pick item to sell");
                int iterator = 1;
                Dictionary<int, IItem> tempDictionary = new Dictionary<int, IItem>();
                foreach (var item in this.ArmorsBag)
                {
                    Console.WriteLine($"{iterator}. {item.Name}  - Sell for {item.ResellValue} gold.");
                    tempDictionary.Add(iterator, item);
                    iterator++;
                }
                foreach (var item in this.WeaponsBag)
                {
                    Console.WriteLine($"{iterator}. {item.Name}  - Sell for {item.ResellValue} gold.");
                    tempDictionary.Add(iterator, item);
                    iterator++;
                }
                foreach (var item in this.PotionBag)
                {
                    Console.WriteLine($"{iterator}. {item.Name}  - Sell for {item.ResellValue} gold.");
                    tempDictionary.Add(iterator, item);
                    iterator++;
                }
                bool result = Int32.TryParse(Console.ReadLine(), out int input);
                if (result == false || input > iterator - 1 || input == 0)
                {
                    Console.WriteLine();
                    Console.WriteLine("Wrong item!");
                    return;
                }

                shop.BuyItemFromHero(hero, tempDictionary[input]);
                this.AddGold(tempDictionary[input].ResellValue);
                Console.WriteLine();
                Console.WriteLine($"{tempDictionary[input].Name} was sold for {tempDictionary[input].ResellValue} gold.");
                Console.WriteLine($"Your total gold now {hero.Gold}");
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Inventory is empty!");
            }

        }
    }
}