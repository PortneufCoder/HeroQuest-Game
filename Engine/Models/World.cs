using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    public class World
    {
        private List<Location> _locations = new List<Location>();

        internal void AddLocation(int xCoordinate, int yCoordinate, string name, string description, string imageName) // I use void so that nothing is returned when this method is called.
        {
            Location loc = new Location();
            loc.XCoordinate = xCoordinate; // the location recieved == parameter set here
            loc.YCoordinate = yCoordinate;
            loc.Name = name;
            loc.Description = description;
            loc.ImageName = imageName;

            _locations.Add(loc);
        }

        public Location LocationAt(int xCoordinate, int yCoordinate)
        {
            foreach(Location loc in _locations)
            {
                if (loc.XCoordinate == xCoordinate && loc.YCoordinate == yCoordinate)
                {
                    return loc;
                }
            }
            return null; // return null if nothing matches
        }
    }
}
