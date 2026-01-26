using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text;

namespace NoNiDev.ArchipelagoParser.ViewModel
{
    class RandoSlotViewModel : NotifyableViewModel
    {
      
        public ObservableCollection<string> PlayerNames
        {
            get => field;
            set
            {
                field.Clear();
                foreach (var item in value)
                    field.Add(item);
                NotifyPropertyChanged();
            }
        }= new ObservableCollection<string>();
        public string SlotName
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }

        }
        public int Checks
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }

        }
        public string Game
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }

        }
        public bool IsInGameList
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public string PlayerName
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }

        }
        public bool IsNameSelected
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public string SelectedName
        {
            get => field;
            set
            {
                field = value;
                IsNameSelected = string.IsNullOrEmpty(value);
                
                NotifyPropertyChanged();
            }
        }

        public RandoSlotViewModel(string slot, string game, int checks)
        {
            IsNameSelected = true;
            IsInGameList = false;
            SlotName = slot;
            Game = game;
            Checks = checks;
            
            RandoStatsViewModel.OnNameListUpdated += UpdateNamesList;
        }
        public void UpdateNamesList(List<string> names)
        {
            PlayerNames.Clear();
            foreach (var item in names)
                PlayerNames.Add(item);
        }
    }
}
