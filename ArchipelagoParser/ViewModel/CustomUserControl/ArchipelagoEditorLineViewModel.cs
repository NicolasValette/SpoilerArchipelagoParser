using NoNiDev.ArchipelagoParser.ViewModel.ArchipelagoEditor;
using NoNiDev.ArchipelagoParser.Views;
using NoNiDev.ArchipelagoParser.Views.CustomWindows;
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
        public State State
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
            State = room.ArchState;
            ButtonEditArchipelRC = new RelayCommand(o => EditArchipel());
            _archipelagoEditorVM = parentVM;
        }
        private ArchipelagoRoom GetRoom() => new ArchipelagoRoom()
        {
            Id = ArchipelId,
            Name = ArchipelName,
            Url = ArchipelURL,
            PlayerNumber = NumberOfPlayers,
            GameNumber = NumberOfGames,
            ArchState = State,
            CheckNumber = NumberOfChecks
        };

        public void EditArchipel()
        {
            var EditWindow = new EditArchipelWindow();
            EditWindow.DataContext = new EditArchipelagoWindowViewModel(GetRoom());
            EditWindow.ShowDialog();

          
        }
    }
}
