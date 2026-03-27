using NoNiDev.ArchipelagoParser.ViewModel.CustomUserControl;
using NoNiDev.CallAPI.RandoStat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NoNiDev.ArchipelagoParser.ViewModel
{
    class ArchipelagoGamesEditorViewModel : NotifyableViewModel
    {
        public RandoStatAPIViewModel RandoStatAPIVM { get; private set; }
        public ArchipelagoGamesEditorViewModel AGEVM => this;
        public bool IsReady
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
        public string ArchipelID
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<ArchipelagoGameEditorLineViewModel> Games
        {
            get => field;
            private set => field = value;
        } = new ObservableCollection<ArchipelagoGameEditorLineViewModel>();

        public RelayCommand ButtonRC { get; }

        public ArchipelagoGamesEditorViewModel()
        {
            ArchipelID = "enter Archipel ID here";
            RandoStatAPIVM = new RandoStatAPIViewModel(APICallType.Get, () => IsReady = true);
            ButtonRC = new RelayCommand(async o => await GetGames());
            
        }
        public async Task GetGames()
        {
            IsAPICallInPrgress = true;
            ApiCallName = "Calling Get Archipel";
            APIToRandoStat.InitURL(RandoStatAPIVM.ApiURL);
            var response = await APIToRandoStat.GetArchipelGames(int.Parse(ArchipelID));
            IsAPICallInPrgress = false;
            ApiCallName = "Request suceed";
        }
    }
}
