using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
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
        public ObservableCollection<RandoSlotViewModel> Players
        {
            get => field;
            private set => field = value;
        } = new ObservableCollection<RandoSlotViewModel>();

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

        public bool IsReady
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }
        public RandoStatsViewModel()
        {
            IsReady = false;
            RandoStatAPIVM = new RandoStatAPIViewModel(APICallType.Get, () => IsReady = true);
            ButtonRC = new RelayCommand(async o => await ButtonCmd());
            StringColor = "#FFDDDDDD";
            IsEnabled = true;
            OpenFileViewModel.OnFileOpened += ReadSpoilers;
        }


        public RelayCommand ButtonRC { get; }
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

            RandoStatData randostat = new RandoStatData
            {
                Action = RandoStatAction.addArchipel,
                Payload = new PayloadAddArchipel
                {
                    Url = "URL",
                    Name = "Magnifigque Archipel",
                    Slots = _option.RandoStats.Slots
                }
            };


           APIToRandoStat.InitURL(RandoStatAPIVM.ApiURL);
            var response= await APIToRandoStat.AddArchipel(randostat);
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

                using var client = new HttpClient();
                var response = await client.GetAsync(url);
                var responseText = await response.Content.ReadAsStringAsync();
                string[]? players = JsonSerializer.Deserialize<string[]>(responseText);
                if (players != null)
                {
                    OnNameListUpdated?.Invoke(players.ToList());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            GetPlayerNamesFromSheet();
        }

    }
}
