using Engine.Models;
using Engine.Factories;
using System.ComponentModel;


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
                // if the world has a location at the X and Y coords to the North, return it
            }
        }

        public bool HasLocationToSouth
        {
            get
            {

                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1) != null;
                // if the world has a location at the X and Y coords to the North, return it
            }
        }

        public bool HasLocationToWest
        {
            get
            {

                return CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate) != null;
                // if the world has a location at the X and Y coords to the North, return it
            }
        }

        public GameSession() 
        {
            // All these objects will bind to the view
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Aragon";
            CurrentPlayer.CharacterClass = "Dunedin";
            CurrentPlayer.HitPoints = 10;
            CurrentPlayer.ExperiencePoints = 0;
            CurrentPlayer.Level = 1;
            CurrentPlayer.Gold = 1000000;


            WorldFactory factory = new WorldFactory();
            CurrentWorld = factory.CreateWorld();

            CurrentLocation = CurrentWorld.LocationAt(0, 0);

        }

        public void MoveNorth()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate + 1);
        }

        public void MoveEast()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate + 1, CurrentLocation.YCoordinate);
        }

        public void MoveWest()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate - 1, CurrentLocation.YCoordinate);
        }

        public void MoveSouth()
        {
            CurrentLocation = CurrentWorld.LocationAt(CurrentLocation.XCoordinate, CurrentLocation.YCoordinate - 1);
        }       
    }
}
