using System;
namespace OOP_RPG
{
    public class Weapon : IItem
    {
        public Weapon(string name, int strength) {
            this.Name = name;
            this.Strength = strength;
        }

        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }
        public string Name { get; set; }
        public int Strength { get; set; }
    }
}