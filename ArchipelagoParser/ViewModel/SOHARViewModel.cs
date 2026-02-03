using System.Collections.ObjectModel;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows;
using NoNiDev.ArchipelagoParser.ViewModel.CustomUserControl;
using NoNiDev.SpoilerArchipelagoParser;
using NoNiDev.SpoilerArchipelagoParser.Options.SOHOptions;

namespace NoNiDev.ArchipelagoParser.ViewModel
{
    public class SOHARViewModel : NotifyableViewModel
    {
        private ArchipelagoOption optionToSend;
        public SoharAPIViewModel SoharAPIVM {  get; private set; }


        public SOHARViewModel SoharVM => this;

        public string StatusBarText
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

        public ObservableCollection<SOHARPlayerLineViewModel> Players
        {
            get => field;
            private set => field = value;
        } = new ObservableCollection<SOHARPlayerLineViewModel>();
        public RelayCommand ButtonRC { get; }
        public SOHARViewModel()
        {
            ApiCallName = "";
            IsAPICallInPrgress = false;
            StatusBarText = "";
            SoharAPIVM = new SoharAPIViewModel(APICallType.Get, () => IsReady = true);

            ButtonRC = new RelayCommand(async o => await ButtonCmd());
            StringColor = "#FFDDDDDD";
            IsEnabled = true;
            OpenFileViewModel.OnFileOpened += ReadSpoilers;
        }

        private async Task ButtonCmd()
        {
           IsAPICallInPrgress = true;
            StringColor = "red";
            foreach (var item in Players)
            {
                if (item.IsChecked)
                {
                    ApiCallName = "Send SOHAR Options : " + item.PlayerName;
                    try
                    {

                        //   RequestResponse = "Send " + item.PlayerName;
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
                        var response = await client.PostAsync(SoharAPIVM.ApiURL, content);
                        var responseText = await response.Content.ReadAsStringAsync();
                        MessageBox.Show(responseText);

                        ApiCallName = "Request Succeed";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        ApiCallName = "Request failed";
                    }

                  //  RequestResponse = "Sent";
                }
            }          
            IsEnabled = true;
            IsAPICallInPrgress = false;
            StringColor = "#FFDDDDDD";
           // RequestResponse = "Request completed successfully";
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
            StreamReader sr = new StreamReader(spoilerPath);
            SpoilerArchipelagoReader spoilerReader = new();
            
            optionToSend = spoilerReader.ReadSpoiler(sr);
            
            Players.Clear();
            foreach (var item in optionToSend.SOHOptions)
            {
                Players.Add(new SOHARPlayerLineViewModel(item.PlayerName));
            }
            StatusBarText = spoilerPath + " loaded.";
            sr.Close();
        }

      
    }

    

    public class SOHARViewModel_DesignTime : SOHARViewModel
    {
        public new List<string> Players => new List<string>();
    }
}
