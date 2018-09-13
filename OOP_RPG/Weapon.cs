using System;
namespace OOP_RPG
{
    public class Weapon : IItem
    {
        public Weapon(string name, int originalValue, int resellValue, int strength)
        {
            Name = name;
            OriginalValue = originalValue;
            ResellValue = resellValue;
            Strength = strength;
        }

        public string Name { get; set; }
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }
        public int Strength { get; set; }
    }
}