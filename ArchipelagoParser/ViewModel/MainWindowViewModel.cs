using System.Windows;

namespace NoNiDev.ArchipelagoParser.ViewModel
{
    public class MainWindowViewModel
    {
        #region Relay Commands
        public RelayCommand ExitRC { get; }
        public RelayCommand AboutRC { get; }
        #endregion
        public MainWindowViewModel()
        {
            ExitRC = new RelayCommand(o => ExitApplication());
            AboutRC = new RelayCommand(o => About());
        }
        public void ExitApplication()
        {
            Environment.Exit(0);
        }
        public void About()
        {
            MessageBox.Show("Archipelago Parser\nVersion 1.0\nDeveloped by NoNiDev");
        }
    }
}
