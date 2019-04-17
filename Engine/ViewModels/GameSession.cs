using Engine.Models;
using Engine.Factories;
using System.ComponentModel;
using System.Linq;

namespace Engine.ViewModels
{
    public class GameSession : BaseNotification //GameSession inherits the code in BaseNotification class
    {
        private Location _currentLocation;

        public World CurrentWorld { get; set; }
        public Player CurrentPlayer { get; set; }

        public Location CurrentLocation {
            get { return _currentLocation; }
                set
                {
                    _currentLocation = value;

                    OnPropertyChanged(nameof(CurrentLocation));
                    OnPropertyChanged(nameof(HasLocationToNorth));
                    OnPropertyChanged(nameof(HasLocationToEast));
                    OnPropertyChanged(nameof(HasLocationToWest));
                    OnPropertyChanged(nameof(HasLocationToSouth));

                    GivePlayerQuestsAtLocation();
            }
        }

        public bool HasLocationToNorth
        {
            get
            {

                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1) != null;
                    // if the world has a location at the X and Y coords to the North, return it
            }
        }

        public bool HasLocationToEast
        {
            get
            {

                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate) != null;
            }
        }

        public bool HasLocationToSouth
        {
            get
            {

                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;
            }
        }

        public bool HasLocationToWest
        {
            get
            {

                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;               
            }
        }

        public GameSession() 
        {
            // All these objects will bind to the view
            CurrentPlayer = new Player
                            {
                                Name = "Aragon",
                                CharacterClass = "Dunedin",
                                HitPoints = 10,
                                ExperiencePoints = 0,
                                Level = 1,
                                Gold = 1000000
                            };

            CurrentWorld = WorldFactory.CreateWorld(); // calls the static WorldFactory class directly without using a new instance of it.

            CurrentLocation = CurrentWorld.LocationAt(0, 0);
        }

        public void MoveNorth()
        {
            // guard condition to prevent errors. Check this condition before setting CurrentLocation
            if (HasLocationToNorth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
            }          
        }

        public void MoveEast()
        {
            if (HasLocationToEast)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
            }          
        }

        public void MoveWest()
        {
            if (HasLocationToWest)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
            }
        }

        public void MoveSouth()
        {
            if (HasLocationToSouth)
            {
                CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
            }
        }
        
        private void GivePlayerQuestsAtLocation()
        {
            foreach(Quest quest in CurrentLocation.QuestsAvailableHere)
            {
                if(!CurrentPlayer.Quests.Any(q => q.PlayerQuest.ID == quest.ID))
                {
                    CurrentPlayer.Quests.Add(new QuestStatus(quest));
                }
            }
        }
    }
}
