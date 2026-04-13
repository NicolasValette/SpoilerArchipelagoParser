using NoNiDev.ArchipelagoParser.App.API;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace NoNiDev.ArchipelagoParser.ViewModel.Options
{
    public class OptionViewModel : NotifyableViewModel
    {
        public string APIRandoStat
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public string APISOHAR
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        private Action _closeCommand;
        public RelayCommand SaveCommand { get; }
        public RelayCommand ResetCommand { get; }
        public OptionViewModel(Action closeCommand)
        {
            _closeCommand = closeCommand;
            LoadAPIConfig();
            SaveCommand = new RelayCommand(o => SaveNewConfig());
            ResetCommand = new RelayCommand(o => ResetNewConfig());
        }
        private void LoadAPIConfig()
        {
            APIRandoStat = APIConfigService.RandoStatApiURL;
            APISOHAR = APIConfigService.SOHARApiURL;
        }
        public void SaveNewConfig()
        {
            APIConfigService.UpdateRandoStatApiURL(APIRandoStat);
            APIConfigService.UpdateSOHARApiURL(APISOHAR);
            _closeCommand?.Invoke();
        }
        public void ResetNewConfig()
        {
            LoadAPIConfig();
            _closeCommand?.Invoke();
        }

    }
}
