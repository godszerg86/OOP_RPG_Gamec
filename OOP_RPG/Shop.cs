using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_RPG
{
    internal class Shop : IShop
    {
        public Shop(List<Weapon> shopWeapons, List<Armor> shopArmor, List<Potion> shopPotion)
        {
            ShopWeapons = shopWeapons;
            ShopArmor = shopArmor;
            ShopPotion = shopPotion;
        }

        public List<Weapon> ShopWeapons { get; set; }
        public List<Armor> ShopArmor { get; set; }
        public List<Potion> ShopPotion { get; set; }
    }

    public interface IShop
    {
        List<Weapon> ShopWeapons { get; set; }
        List<Armor> ShopArmor { get; set; }
        List<Potion> ShopPotion { get; set; }
    }
}
