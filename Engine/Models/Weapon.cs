using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class Weapon : GameItem // weapon class is a sub-class of GameItem
    {
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        // When we instantiate a weapon object we pass in these params
        // and the values that are passed in are sent to the base class GameItem
        public Weapon(int itemTypeID, string name, int price, int minDamage, int maxDamage) 
            : base(itemTypeID, name, price)
        {
            MinimumDamage = minDamage; // the property is equal tot he value of the parameter
            MaximumDamage = minDamage;
        }

        public new Weapon Clone()
        {
            return new Weapon(ItemTypeID, Name, Price, MinimumDamage, MaximumDamage);
        }
    }
}
