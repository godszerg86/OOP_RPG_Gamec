using System;


namespace OOP_RPG
{
    public class Potion : IItem
    {
        public Potion(string name, int originalValue, int resellValue, int hP)
        {
            Name = name;
            OriginalValue = originalValue;
            ResellValue = resellValue;
            HP = hP;
        }

        public string Name { get; set; }
        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }
        public int HP { get; set; }
    }
}