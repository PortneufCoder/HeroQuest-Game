﻿
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

        private void OnClick_MoveNorth(object sender, RoutedEventArgs e) // visible only within this class
        {
            _gameSession.MoveNorth(); // call my functions in the game session class
        }

        private void OnClick_MoveWest(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveWest();
        }

        private void OnClick_MoveEast(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveEast();
        }

        private void OnClick_MoveSouth(object sender, RoutedEventArgs e)
        {
            _gameSession.MoveSouth();
        }

    }
}
