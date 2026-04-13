using NoNiDev.ArchipelagoParser.App;
using NoNiDev.ArchipelagoParser.Views.Options;
using System.Windows;

namespace NoNiDev.ArchipelagoParser.ViewModel
{
    public class MainWindowViewModel
    {
        #region Relay Commands
        public RelayCommand ExitRC { get; }
        public RelayCommand AboutRC { get; }
        public RelayCommand OpenOptionRC { get; }
        #endregion
        public MainWindowViewModel()
        {
            ExitRC = new RelayCommand(o => ExitApplication());
            AboutRC = new RelayCommand(o => About());
            OpenOptionRC = new RelayCommand(o => OpenOption());
        }
        public void ExitApplication()
        {
            Environment.Exit(0);
        }
        public void OpenOption()
        {
            OptionsWindow optionsWindow = new OptionsWindow();
            optionsWindow.Show();
        }
        public void About()
        {
            string appVersion = $"Version {AppInfoService.AssemblyVersion}";
            MessageBox.Show($"Archipelago Parser\n{appVersion}\nDeveloped by NoNiDev");
        }
    }
}
