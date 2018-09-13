using System;
namespace OOP_RPG
{
    public class Armor : IItem
    {

        // class constructor accept name of Armor and Defese score


        public Armor(string name, int originalValue, int resellValue, int defense)
        {
            OriginalValue = originalValue;
            ResellValue = resellValue;
            Name = name;
            Defense = defense;
        }

        // properties of Armor
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }
        public string Name { get; set; }
        public int Defense { get; set; }
    }
}