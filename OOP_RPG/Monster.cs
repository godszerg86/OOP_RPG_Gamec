using System;
using System.Collections.Generic;

namespace OOP_RPG
{
    public class Monster
    {
        public string Name { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHP { get; set; }
        public int CurrentHP { get; set; }

        public Monster(string name = "Monster", int strength = 5, int defense = 2, int originalHP = 10)
        {
            this.Name = name;
            this.Strength = strength;
            this.Defense = defense;
            this.OriginalHP = originalHP;
            this.CurrentHP = originalHP;
            
        }
    }


}