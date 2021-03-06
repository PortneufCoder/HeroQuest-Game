﻿using System;
using Engine.Models;
using Engine.Factories;
using System.Linq;
using Engine.EventArgs;

namespace Engine.ViewModels
{
    public class GameSession : BaseNotification // GameSession inherits the code in BaseNotification class
    {
        public event EventHandler<GameMessageEventArgs> OnMessageRaised;

        #region Properties

        private Location _currentLocation;
        private Monster _currentMonster;

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
                    GetMonsterAtLocation();
            }
        }

        public Monster CurrentMonster
        {
            get { return _currentMonster; }
            set
            {
                _currentMonster = value;

                OnPropertyChanged(nameof(CurrentMonster));
                OnPropertyChanged(nameof(HasMonster));

                if(CurrentMonster != null)
                {
                    RaiseMessage("");
                    RaiseMessage($"You've met a {CurrentMonster.Name} here!");
                }
            }
        }

        public Weapon CurrentWeapon { get; set; }

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

        public bool HasMonster
        {
            get
            {
                return CurrentMonster != null;
            }
        }

        #endregion

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

            if (!CurrentPlayer.Weapons.Any())
            {
                CurrentPlayer.AddItemToInventory(ItemFactory.CreateGameItem(1001));
            }

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

        private void GetMonsterAtLocation()
        {
            CurrentMonster = CurrentLocation.GetMonster(); 
        }

        public void AttackCurrentMonster()
        {
            if (CurrentWeapon == null)
            {
                RaiseMessage("You must select a weapon, to attack.");
                return;
            }

            // Determine damage to monster
            int damageToMonster = RandomNumberGenerator.NumberBetween(CurrentWeapon.MinimumDamage, CurrentWeapon.MaximumDamage);

            if (damageToMonster == 0)
            {
                RaiseMessage($"You missed the {CurrentMonster.Name}.");
            }
            else
            {
                CurrentMonster.HitPoints -= damageToMonster;
                RaiseMessage($"You hit the {CurrentMonster.Name} for {damageToMonster} points.");
            }

            // If monster if killed, collect rewards and loot
            if (CurrentMonster.HitPoints <= 0)
            {
                RaiseMessage("");
                RaiseMessage($"You defeated the {CurrentMonster.Name}!");

                CurrentPlayer.ExperiencePoints += CurrentMonster.RewardExperiencePoints;
                RaiseMessage($"You receive {CurrentMonster.RewardExperiencePoints} experience points.");

                CurrentPlayer.Gold += CurrentMonster.RewardGold;
                RaiseMessage($"You receive {CurrentMonster.RewardGold} gold.");

                foreach (ItemQuantity itemQuantity in CurrentMonster.Inventory)
                {
                    GameItem item = ItemFactory.CreateGameItem(itemQuantity.ItemID);
                    CurrentPlayer.AddItemToInventory(item);
                    RaiseMessage($"You receive {itemQuantity.Quantity} {item.Name}.");
                }

                // Get another monster to fight
                GetMonsterAtLocation();
            }
            else
            {
                // If monster is still alive, let the monster attack
                int damageToPlayer = RandomNumberGenerator.NumberBetween(CurrentMonster.MinimumDamage, CurrentMonster.MaximumDamage);

                if (damageToPlayer == 0)
                {
                    RaiseMessage("The monster attacks, but misses you.");
                }
                else
                {
                    CurrentPlayer.HitPoints -= damageToPlayer;
                    RaiseMessage($"The {CurrentMonster.Name} hit you for {damageToPlayer} points.");
                }

                // If player is killed, move them back to their home.
                if (CurrentPlayer.HitPoints <= 0)
                {
                    RaiseMessage("");
                    RaiseMessage($"The {CurrentMonster.Name} killed you.");

                    CurrentLocation = CurrentWorld.LocationAt(0, -1); // Player's home
                    CurrentPlayer.HitPoints = CurrentPlayer.Level * 10; // Completely heal the player
                }
            }
        }

        private void RaiseMessage(string message)
        {
            OnMessageRaised?.Invoke(this, new GameMessageEventArgs(message));
        }
    }
}
