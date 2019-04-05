using Engine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Engine.ViewModels
{
    public class GameSession
    {
        public Player CurrentPlayer { get; set; }

        public GameSession()
        {
            // All these objects will bind to the view
            CurrentPlayer = new Player();
            CurrentPlayer.Name = "Victor";
            CurrentPlayer.CharacterClass = "NinjaDude";
            CurrentPlayer.HitPoints = 10;
            CurrentPlayer.ExperiencePoints = 0;
            CurrentPlayer.Level = 1;
            CurrentPlayer.Gold = 1000000;
        }
    }
}
