using NoNiDev.ArchipelagoParser.Data.Enums;
using NoNiDev.CallAPI.RandoStat;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.ArchipelagoParser.ViewModel.ArchipelagoEditor
{
    public class EditArchipelagoWindowViewModel : NotifyableViewModel
    {
        public string Name
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public string Url
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
        public List<string> StateList => Enum.GetNames(typeof(State)).ToList();

        public RelayCommand SendModificationRC { get; }
        public RelayCommand ExitRC { get; }
        public EditArchipelagoWindowViewModel(ArchipelagoRoom room)
        {
            Name = room.Name;
            Url = room.Url;
            State = room.ArchState.ToString();
            SendModificationRC = new RelayCommand(async o => await SendModification());
            ExitRC = new RelayCommand(o => CloseWindow());
        }
        public async Task SendModification()
        {

        }
        public void CloseWindow()
        {
        
        }

    }
}
