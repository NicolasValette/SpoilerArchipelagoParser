using NoNiDev.ArchipelagoParser.App;
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
            string appVersion = $"Version {AppInfoService.AssemblyVersion}";
            MessageBox.Show($"Archipelago Parser\n{appVersion}\nDeveloped by NoNiDev");
        }
    }
}
