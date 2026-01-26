using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Dynamic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using NoNiDev.ArchipelagoParser.Views;
using NoNiDev.CallAPI.RandoStat;
using NoNiDev.SpoilerArchipelagoParser;
using NoNiDev.SpoilerArchipelagoParser.SOHOptions;

namespace NoNiDev.ArchipelagoParser.ViewModel
{
    class RandoStatsViewModel : NotifyableViewModel
    {
        public static event Action<List<string>> OnNameListUpdated;
        private ArchipelagoOption _option;

        public RandoStatAPIViewModel RandoStatAPIVM { get; private set; }
        private List<string> _names = new List<string>();
        private List<string> _missingGames = new List<string>();

        #region Binded Properties
        public ObservableCollection<RandoSlotViewModel> Players
        {
            get => field;
            private set => field = value;
        } = new ObservableCollection<RandoSlotViewModel>();

        public string StatusBarText
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }

        }
        public string StringColor
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
        public bool IsReady
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsAddJeuVisible
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public bool IsReadyToAddArchipel
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
        public string URL
        {             
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        #endregion
        #region Relay Commands
        public RelayCommand ButtonRC { get; }
        public RelayCommand ButtonAddJoueurRC { get; }
        public RelayCommand ButtonAddJeuxRC { get; }
        #endregion
        public RandoStatsViewModel()
        {
            IsReadyToAddArchipel = false;
            IsAPICallInPrgress = false;
            IsAddJeuVisible = false;
            IsReady = false;
            RandoStatAPIVM = new RandoStatAPIViewModel(APICallType.Get, () => IsReady = true);
            ButtonRC = new RelayCommand(async o => await ButtonCmd());
            ButtonAddJoueurRC = new RelayCommand(async o => await AddJoueur());
            ButtonAddJeuxRC = new RelayCommand(async o => await AddJeux());
            StringColor = "#FFDDDDDD";
            IsEnabled = true;
            OpenFileViewModel.OnFileOpened += ReadSpoilers;
        }


        private async Task ButtonCmd()
        {
            RandoStatAPIVM.RequestResponse = "ButtonCmd";
            StringColor = "red";
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            RandoStatAPIVM.RequestResponse = "Calling...";
            List<NoNiDev.SpoilerArchipelagoParser.RandoStats.ArchippelagoSlot> slotToSent = new List<NoNiDev.SpoilerArchipelagoParser.RandoStats.ArchippelagoSlot>();
            foreach (var item in Players)
            {
                SpoilerArchipelagoParser.RandoStats.ArchippelagoSlot slot = new NoNiDev.SpoilerArchipelagoParser.RandoStats.ArchippelagoSlot(item.SelectedName, item.Game, item.Checks);
                
                slotToSent.Add(slot);
            }
            RandoStatData randostat = new RandoStatData
            {
                Action = RandoStatAction.addArchipel,
                Payload = new PayloadAddArchipel
                {
                    Url = URL,
                    Name = ArchipelName,
                    Slots = slotToSent
                }
            };


            APIToRandoStat.InitURL(RandoStatAPIVM.ApiURL);
            var response = await APIToRandoStat.AddArchipel(randostat);
            MessageBox.Show(response);
            IsEnabled = true;
            StringColor = "#FFDDDDDD";
            RandoStatAPIVM.RequestResponse = "Request completed successfully";
        }

        private async void GetPlayerNamesFromSheet()
        {
            string url = RandoStatAPIVM.ApiURL + "?action=joueurs";
            try
            {
                IsAPICallInPrgress = true;
                using var client = new HttpClient();
                var response = await client.GetAsync(url);
                var responseText = await response.Content.ReadAsStringAsync();
                string[]? players = JsonSerializer.Deserialize<string[]>(responseText);
                if (players != null)
                {
                    OnNameListUpdated?.Invoke(players.ToList());
                }
                IsAPICallInPrgress = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private async void GetGameNamesFromSheet()
        {
            IsAPICallInPrgress = true;
            APIToRandoStat.InitURL(RandoStatAPIVM.ApiURL);
            string[] gameNames = await APIToRandoStat.GetGameNames();
            _missingGames.Clear();
            foreach (var item in _option.RandoStats.Slots)
            {
                if (!gameNames.Contains(item.Game) && !_missingGames.Contains(item.Game))
                {
                    _missingGames.Add(item.Game);
                }
                else
                {
                    Players.Where(p => p.SlotName.CompareTo(item.Name) == 0).First().IsInGameList = true;
                }
            }
            if (_missingGames.Count > 0)
            {
                IsAddJeuVisible = true;
            }
            IsAPICallInPrgress = false;
        }

        private async Task AddJoueur()
        {
            PopUpWindow wind = new PopUpWindow();
            wind.ShowDialog();
            IsAPICallInPrgress = true;
            string name = wind.UserInput.Text;
            APIToRandoStat.InitURL(RandoStatAPIVM.ApiURL);

            var response = await APIToRandoStat.AddPlayer(name);

            IsAddJeuVisible = false;
            int idWhereToAdd = -1;

            if (idWhereToAdd == -1)
            {
                for (int i = 0; i < Players[0].PlayerNames.Count; i++)
                {
                    if (Players[0].PlayerNames[i].CompareTo(name) < 0)
                    {
                        idWhereToAdd = i + 1;
                        break;
                    }

                }
            }
            foreach (var item in Players)
            {
                item.PlayerNames.Insert(idWhereToAdd, name);
            }


            IsAPICallInPrgress = false;
        }
        private async Task AddJeux()
        {
            IsAPICallInPrgress = true;
            var result = MessageBox.Show("Ajout des jeux manquants : " + string.Join(", ", _missingGames), "Ajout de jeux", MessageBoxButton.OKCancel);
            if (result == MessageBoxResult.OK)
            {
                APIToRandoStat.InitURL(RandoStatAPIVM.ApiURL);
                foreach (var game in _missingGames)
                {
                    var response = await APIToRandoStat.AddGame(game);
                }
                IsAddJeuVisible = false;
            }
            IsAPICallInPrgress = false;
        }
        private void ReadSpoilers(string spoilerPath)
        {

            StreamReader sr = new StreamReader(spoilerPath);
            SpoilerArchipelagoReader spoilerReader = new();

            _option = spoilerReader.ReadSpoiler(sr);

            Players.Clear();
            foreach (var item in _option.RandoStats.Slots)
            {
                //Players.Add(item.PlayerName);
                var slot = new RandoSlotViewModel(item.Name, item.Game, item.LocationCount);
                Players.Add(slot);

            }

            sr.Close();
            StatusBarText = spoilerPath + " loaded.";
            GetPlayerNamesFromSheet();
            GetGameNamesFromSheet();
            IsReadyToAddArchipel = true;
        }

    }
}
