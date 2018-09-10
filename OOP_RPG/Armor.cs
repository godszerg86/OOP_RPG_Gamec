using System;
namespace OOP_RPG
{
    public class Armor
    {

        // class constructor accept name of Armor and Defese score
        public Armor(string name, int defense) {
            this.Name = name;
            this.Defense = defense;
        }
        
        
        // properties of Armor
        public string Name { get; set; }
        public int Defense { get; set; }
    }
}