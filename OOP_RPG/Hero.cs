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
        public Hero() {
            this.ArmorsBag = new List<Armor>();
            this.WeaponsBag = new List<Weapon>();
            this.Strength = 10;
            this.Defense = 10;
            this.OriginalHP = 30;
            this.CurrentHP = 30;
            this.Gold = 0;
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

        public List<Armor> ArmorsBag { get; set;}
        public List <Weapon> WeaponsBag { get; set; }
        
        //These are the Methods of our Class.
        public void ShowStats() {
            Console.WriteLine("*****" + this.Name + "*****");
            Console.WriteLine("Strength: " + this.Strength);
            Console.WriteLine("Defense: " + this.Defense);
            Console.WriteLine("Hitpoints: " + this.CurrentHP + "/" + this.OriginalHP);
        }
        
        public void ShowInventory() {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("*****  INVENTORY ******");
            Console.WriteLine();
            Console.ResetColor();
            Console.BackgroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Weapons: ");
            Console.ResetColor();
            foreach (var w in this.WeaponsBag){
                Console.WriteLine(w.Name + " of " + w.Strength + " Strength");
            }
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Armor: ");
            Console.ResetColor();
            foreach(var a in this.ArmorsBag){
                Console.WriteLine(a.Name + " of " + a.Defense + " Defense");
            }
            Console.BackgroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("Gold: " + this.Gold);
            Console.ResetColor();
           
        }
        
        public void EquipWeapon() {
            if(WeaponsBag.Any()) {
                this.EquippedWeapon = this.WeaponsBag[0];
            }
        }
        
        public void EquipArmor() {
            if(ArmorsBag.Any()) {
                this.EquippedArmor = this.ArmorsBag[0];
            }
        }

        internal void AddGold(int gold)
        {
            this.Gold = gold;
        }
    }
}