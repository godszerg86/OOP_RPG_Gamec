using System;


namespace OOP_RPG
{
    public class Potion : IItem
    {
        public Potion(int hP, string name)
        {
            HP = hP;
            Name = name;
        }

        public int HP { get; set; }
        public string Name { get; set; }

        public int OriginalValue { get; set; }
        public int ResellValue { get; set; }
    }
}