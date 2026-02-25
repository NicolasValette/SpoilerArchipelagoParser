using NoNiDev.ArchipelagoParser.SpoilerLoader;
using NoNiDev.ArchipelagoParser.ViewModel.CustomUserControl;
using NoNiDev.ArchipelagoParser.ViewModel.SpoilerViewer;
using NoNiDev.ArchipelagoParser.Views.CustomUserControl.SpoilerViewer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NoNiDev.ArchipelagoParser.ViewModel
{
    public class Game (string name)
    {
        public string Name { get; set; } = name;
    }
    class SpoilerViewModel : NotifyableViewModel
    {
        public ObservableCollection<SpoilerGameItemViewModel> Games
        {
            get => field;
            private set => field = value;
        } = new ObservableCollection<SpoilerGameItemViewModel>();

        public SpoilerViewModel()
        {
            SpoilerHandler.OnSpoilerLoaded += LoadSpoiler;
        }
        public void LoadSpoiler()
        {
            if (SpoilerHandler.ArchiOption is not null)
            {
                foreach (var game in SpoilerHandler.ArchiOption.SOHOptionsList)
                {
                    Games.Add(new SpoilerGameItemViewModel(game));
                }   
            }
        }
    }
}
