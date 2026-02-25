using NoNiDev.SpoilerArchipelagoParser.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace NoNiDev.ArchipelagoParser.ViewModel.SpoilerViewer
{
    class SpoilerGameItemViewModel : NotifyableViewModel
    {
        public ObservableCollection<SpoilerGameItemLineViewModel> ListOption
        {
            get => field;
            private set => field = value;
        } = new ObservableCollection<SpoilerGameItemLineViewModel>();

        public string GamePlusName
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }

        }

        private GameOptions _gameOption;
        public SpoilerGameItemViewModel(GameOptions gameOption)
        {
            _gameOption = gameOption;

            GamePlusName = $"{_gameOption.Game} -- {_gameOption.PlayerName}";
            foreach (var item in _gameOption.GameOptionsDictionnary)
            {
                if (string.IsNullOrEmpty(item.Value))
                    continue;
                ListOption.Add(new SpoilerGameItemLineViewModel(item.Key, item.Value));
            }
        }
    }
}
