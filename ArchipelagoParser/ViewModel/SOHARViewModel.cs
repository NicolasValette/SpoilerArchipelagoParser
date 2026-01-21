using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing.Imaging.Effects;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using ArchipelagoParser;
using NoNiDev.ArchipelagoParser.Views;
using NoNiDev.SpoilerArchipelagoParser;
using NoNiDev.SpoilerArchipelagoParser.SOHOptions;

namespace NoNiDev.ArchipelagoParser.ViewModel
{
    public class SOHARViewModel : NotifyableViewModel
    {
        private ArchipelagoOption optionToSend;
        public string ApiURL
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }
        }

        public string RequestResponse
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

        public ObservableCollection<SOHARPlayerLineViewModel> Players
        {
            get => field;
            private set => field = value;
        } = new ObservableCollection<SOHARPlayerLineViewModel>();
        public RelayCommand ButtonRC { get; }
        public SOHARViewModel()
        {
            ApiURL = "API URL";
            RequestResponse = "Response will be here";
            ButtonRC = new RelayCommand(async o => await ButtonCmd());
            StringColor = "#FFDDDDDD";
            IsEnabled = true;
            OpenFileViewModel.OnFileOpened += ReadSpoilers;
        }

        private async Task ButtonCmd()
        {
            RequestResponse = "ButtonCmd";
            StringColor = "red";
            RequestResponse = "Calling...";
            foreach (var item in Players)
            {
                if (item.IsChecked)
                {
                    RequestResponse = "Send " + item.PlayerName;
                    var opt = optionToSend.GetSOHOptions(item.PlayerName);
                    opt.PlayerName = item.PlayerToSend.ToString();
                    var options = new JsonSerializerOptions
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    };
                    string jsonString = JsonSerializer.Serialize<SOHPlayerOptions>(opt, options);
                    using var client = new HttpClient();
                    using var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                    var response = await client.PostAsync(ApiURL, content);
                    var responseText = await response.Content.ReadAsStringAsync();
                    RequestResponse = "Sent";
                }
            }          
            IsEnabled = true;
            StringColor = "#FFDDDDDD";
            RequestResponse = "Request completed successfully";
        }

        //Appel GET
        //private async Task ButtonCmd()
        //{
        //    RequestResponse = "ButtonCmd";
        //    StringColor = "red";

        //    RequestResponse = "Calling...";
        //    string url = ApiURL + "?action=joueurs";
        //    using var client = new HttpClient();
        //    var response = await client.GetAsync(url);
        //    var responseText = await response.Content.ReadAsStringAsync();
        //    string[]? players = JsonSerializer.Deserialize<string[]>(responseText);

        //    RequestResponse = "CALLED";
        //    if (players != null)
        //    {
        //        Players.Clear();
        //        foreach (var item in players)
        //        {
        //            //Players.Add(item);
        //        }
        //    }
        //    IsEnabled = true;
        //    StringColor = "#FFDDDDDD";
        //    RequestResponse = "Request completed successfully";
        //}

        private void ReadSpoilers(string spoilerPath)
        {
            RequestResponse = "Spoiler path : " + spoilerPath;
            StreamReader sr = new StreamReader(spoilerPath);
            SpoilerArchipelagoReader spoilerReader = new();
            
            optionToSend = spoilerReader.ReadSpoiler(sr);
            
            Players.Clear();
            foreach (var item in optionToSend.SOHOptions)
            {
                //Players.Add(item.PlayerName);
                Players.Add(new SOHARPlayerLineViewModel(item.PlayerName));

            }
            
            sr.Close();
        }

      
    }

    

    public class SOHARViewModel_DesignTime : SOHARViewModel
    {
        public new List<string> Players => new List<string>();
        //public SOHARViewModel_DesignTime()
        //{
        //    Players.AddRange(new []{ "SOHAR View Model", "2", "3" });
        //}
    }
}
