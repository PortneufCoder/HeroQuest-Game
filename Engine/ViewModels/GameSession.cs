using Engine.Models;


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
