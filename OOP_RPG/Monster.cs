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

        public Monster(string name, int strength, int defense, int originalHP)
        {
            this.Name = name;
            this.Strength = strength;
            this.Defense = defense;
            this.OriginalHP = originalHP;
            this.CurrentHP = originalHP;
        }
    }


}