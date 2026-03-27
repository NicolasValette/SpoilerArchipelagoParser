using NoNiDev.CallAPI.RandoStat;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace NoNiDev.ArchipelagoParser.ViewModel.CustomUserControl
{
    class ArchipelagoEditorLineViewModel : NotifyableViewModel
    {
        private ArchipelagoEditorViewModel _archipelagoEditorVM;
        public int ArchipelId
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public string ArchipelName
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public string ArchipelURL
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public int NumberOfPlayers
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public int NumberOfGames
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public string State
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public int NumberOfChecks
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public RelayCommand ButtonEditArchipelRC { get; }

        public ArchipelagoEditorLineViewModel(ArchipelagoRoom room, ArchipelagoEditorViewModel parentVM)
        {
            ArchipelId = room.Id;
            ArchipelName = room.Name;
            NumberOfPlayers = room.PlayerNumber;
            NumberOfChecks = room.CheckNumber;
            NumberOfGames = room.GameNumber;
            ArchipelURL = room.Url;
            State = room.State;
            ButtonEditArchipelRC = new RelayCommand(o => EditArchipel());
            _archipelagoEditorVM = parentVM;
        }
        public void EditArchipel()
        {
            MessageBox.Show("Edit " + ArchipelName);
        }
    }
}
