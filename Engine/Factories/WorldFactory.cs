
using Engine.Models;

namespace Engine.Factories
{
    internal static class WorldFactory
    {
        internal static World CreateWorld()
        {
            World newWorld = new World();

            newWorld.AddLocation(0, -1, "Home", "This is your home", 
                "/Engine;component/Images/Locations/Home.png");

            newWorld.AddLocation(-1, -1, "Farmer's House",
                "This is Old McDonald's house", "/Engine;component/Images/Locations/Farmhouse.png");

            newWorld.AddLocation(-2, -1, "Farmer's Field", 
                "Beware of this corn field, there are giant rats lurking within it.",
                "/Engine;component/Images/Locations/FarmFields.png");

            newWorld.LocationAt(-2, -1).AddMonster(2, 100);

            newWorld.AddLocation(-1, 0, "Trading Inn", "The inn of Leoksa, the trader.",
                "/Engine;component/Images/Locations/Trader.png");

            newWorld.AddLocation(0, 0, "Town Square", "The fountain is your clue",
                "/Engine;component/Images/Locations/TownSquare.png");

            newWorld.AddLocation(1, 0, "Town Gate", 
                "There is a huge gate here to shield the town from giant arachnids",
                "/Engine;component/Images/Locations/TownGate.png");

            newWorld.AddLocation(2, 0, "Spider Forest", 
                "The trees in this forest are teeming with webs... and spiders",
                "/Engine;component/Images/Locations/SpiderForest.png");

            newWorld.LocationAt(-2, 0).AddMonster(3, 100);

            newWorld.AddLocation(0, 1, "Herbalist's Cottage", 
                "You see a hay-covered cottage, with herbs, drying outside",
                "/Engine;component/Images/Locations/HerbalistsHut.png");

            newWorld.LocationAt(0, 1).QuestsAvailableHere.Add(QuestFactory.GetQuestByID(1));

            newWorld.AddLocation(0, 2, "Herbalist garden", 
                "Watch out! There are many medicinal plants here, but snakes hide amongst them!",
                "/Engine;component/Images/Locations/HerbalistsGarden.png");

            newWorld.LocationAt(0, 2).AddMonster(1, 100);

            return newWorld; // instantiate a new world object and return it where its called
        }
    }
}
