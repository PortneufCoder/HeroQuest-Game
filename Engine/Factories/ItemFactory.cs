﻿using Engine.Models;
using System.Collections.Generic;
using System.Linq;

namespace Engine.Factories
{
    public static class ItemFactory // static because we are only going to use the functions in it
    {
        private static List<GameItem> _standardGameItems; // list of all items in the game

        static ItemFactory()
        {
            _standardGameItems = new List<GameItem>();

            _standardGameItems.Add(new Weapon(1001, "Pointy Stick", 1, 1, 2));
            _standardGameItems.Add(new Weapon(1002, "Rusty Sword", 5, 1, 3));
            _standardGameItems.Add(new GameItem(9001, "Viper fang", 1));
            _standardGameItems.Add(new GameItem(9002, "Viperskin", 2));
            _standardGameItems.Add(new GameItem(9003, "Evil Beaver tail", 1));
            _standardGameItems.Add(new GameItem(9004, "Evil Beaver pelt", 2));
            _standardGameItems.Add(new GameItem(9005, "Spider fang", 1));
            _standardGameItems.Add(new GameItem(9006, "Spider silk", 2));
        }

        public static GameItem CreateGameItem(int itemTypeID)
        {
            GameItem standardItem = _standardGameItems.FirstOrDefault(item => item.ItemTypeID == itemTypeID);

            if(standardItem != null)
            {
                if (standardItem is Weapon)
                {
                    return (standardItem as Weapon).Clone();
                }

                return standardItem.Clone();
            }

            return null;
        }
    }
}
