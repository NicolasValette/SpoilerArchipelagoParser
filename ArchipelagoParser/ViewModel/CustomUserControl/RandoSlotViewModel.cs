using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Text;

namespace NoNiDev.ArchipelagoParser.ViewModel.CustomUserControl
{
    class RandoSlotViewModel : NotifyableViewModel
    {
        private Func<string, bool> _gameListContainsGameName;
        private Action<string> IsManualToggle;
        #region Properties
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
        public bool IsManual
        {
            get => field;
            set
            {
                field = value;
                if (field)
                    IsInGameList = true;
                else
                {
                    IsInGameList = false;
                }
                IsManualToggle?.Invoke(Game);
                NotifyPropertyChanged();
            }
        }
        public bool IsManualCheckboxEnabled
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public string IsManualCheckboxStr => IsManualCheckboxEnabled.ToString();
        #endregion

        public RandoSlotViewModel(string slot, string game, int checks, Func<string, bool> gameListContainsGameName, Action<string> isManualToggle)
        {
            IsManual = false;
            IsManualCheckboxEnabled = false;
            IsNameSelected = true;
            IsInGameList = false;
            SlotName = slot;
            Game = game;
            Checks = checks;
            _gameListContainsGameName = gameListContainsGameName;
            IsManualToggle = isManualToggle;

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
