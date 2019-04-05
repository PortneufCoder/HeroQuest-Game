
using System.Windows;
using Engine.ViewModels;

namespace WPFUI
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private GameSession _gameSession; // private var

        public MainWindow()
        {
            InitializeComponent();

            _gameSession = new GameSession(); // instantiate new game session

            DataContext = _gameSession;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            // when clicked add 10 to current XP
            _gameSession.CurrentPlayer.ExperiencePoints = _gameSession.CurrentPlayer.ExperiencePoints + 10;
        }
    }
}
