using System.Collections.ObjectModel;


namespace Engine.Models
{
    public class Monster : BaseNotification
    {
        private int _hitPoints;

        public string Name { get; private set; }
        public string ImageName { get; set; }
        public int MaximumHitPoints { get; private set; }
        public int HitPoints
        {
            get { return _hitPoints;  }
            set
            {
                _hitPoints = value;
                OnPropertyChanged(nameof(HitPoints));
            }
        }

        // Ability for the monster to fight
        public int MinimumDamage { get; set; }
        public int MaximumDamage { get; set; }

        public int RewardExperiencePoints { get; private set; }
        public int RewardGold { get; private set; }

        public ObservableCollection<ItemQuantity> Inventory { get; set; }

        public Monster(string name, string imageName,
            int maximumHitPoints, int hitPoints,
            int rewardExperiencePoints, int rewardGold,
            int minimumDamage, int maximumDamage)
        {
            Name = name;
            ImageName = string.Format("/Engine;component/Images/Monsters/{0}", imageName);
            MaximumHitPoints = maximumHitPoints;
            HitPoints = hitPoints;
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            MinimumDamage = minimumDamage;
            MaximumDamage = maximumDamage;

            Inventory = new ObservableCollection<ItemQuantity>();
        }
    }
}
