using NoNiDev.ArchipelagoParser.ViewModel.CustomUserControl;
using NoNiDev.ArchipelagoParser.Views.CustomUserControl.ArchipelagoEditor;
using NoNiDev.CallAPI.RandoStat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NoNiDev.ArchipelagoParser.ViewModel
{
    class ArchipelagoEditorViewModel : NotifyableViewModel
    {
        public RandoStatAPIViewModel RandoStatAPIVM { get; private set; }
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
            RandoStatAPIVM = new RandoStatAPIViewModel(APICallType.Get, () => IsReady = true);
            ButtonGetArchipelRC = new RelayCommand(async o=> await GetArchipel());
            IsEnabled = true;
        }

        public async Task GetArchipel()
        {
            IsEnabled = false;
            IsAPICallInPrgress = true;
            ApiCallName = "Calling Get Archipel";
            APIToRandoStat.InitURL(RandoStatAPIVM.ApiURL);
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
    }
}
