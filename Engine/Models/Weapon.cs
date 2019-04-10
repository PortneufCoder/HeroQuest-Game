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
            MinimumDamage = minDamage;
            MaximumDamage = minDamage;
        }
    }
}
