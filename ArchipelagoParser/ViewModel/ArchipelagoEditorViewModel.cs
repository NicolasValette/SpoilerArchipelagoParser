using NoNiDev.ArchipelagoParser.App.API;
using NoNiDev.ArchipelagoParser.ViewModel.CustomUserControl;
using NoNiDev.ArchipelagoParser.Views.CustomUserControl.ArchipelagoEditor;
using NoNiDev.CallAPI.RandoStat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;

namespace NoNiDev.ArchipelagoParser.ViewModel
{
    class ArchipelagoEditorViewModel : NotifyableViewModel
    {
       
        public ArchipelagoEditorViewModel AEVM => this;
        public bool IsReady
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsEnabled
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsAPICallInPrgress
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public string ApiCallName
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<ArchipelagoEditorLineViewModel> Rooms
        {
            get => field;
            private set => field = value;
        } = new ObservableCollection<ArchipelagoEditorLineViewModel>();
        public RelayCommand ButtonGetArchipelRC { get; }

        public ArchipelagoEditorViewModel()
        {
            
            ButtonGetArchipelRC = new RelayCommand(async o=> await GetArchipel());
            IsEnabled = true;
        }

        public async Task GetArchipel()
        {
            IsEnabled = false;
            IsAPICallInPrgress = true;
            ApiCallName = "Calling Get Archipel";
            APIToRandoStat.InitURL(APIConfigService.RandoStatApiURL);
            List<ArchipelagoRoom> response = await APIToRandoStat.GetArchipel();
            IsAPICallInPrgress = false;
            ApiCallName = "Request suceed";
            IsEnabled = true;
            Rooms.Clear();
            foreach (ArchipelagoRoom room in response)
            {
                Rooms.Add(new ArchipelagoEditorLineViewModel(room, this));
            }
        }
        public async Task EditArchipel(ArchipelagoRoom room)
        {
            IsEnabled = false;
            IsAPICallInPrgress = true;
            ApiCallName = "Calling Edit Archipel";
            APIToRandoStat.InitURL(APIConfigService.RandoStatApiURL);
            string response = await APIToRandoStat.EditArchipel(room);
            IsAPICallInPrgress = false;
            ApiCallName = "Request suceed";
            IsEnabled = true;
            MessageBox.Show(response);
        }
        
    }
}
