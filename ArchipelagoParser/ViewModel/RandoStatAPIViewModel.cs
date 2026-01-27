using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Windows.Controls;
using System.Windows.Media;

namespace NoNiDev.ArchipelagoParser.ViewModel
{
    public enum APICallType
    {
        Get,
        Post
    }
    class RandoStatAPIViewModel : NotifyableViewModel
    {
        private Action _readynessCallback;
        private APICallType _callTYpe;
        public string ApiURL
        {
            get => field;
            set
            {
                field = value;
                if (value != null && value != "Enter API URL")
                    SaveAPIConfig();
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

        

        public RandoStatAPIViewModel(APICallType callTYpe, Action callback)
        {
            _readynessCallback = callback;
            LoadAPIConfig();
            RequestResponse = "Response will be here";
                   _callTYpe = callTYpe;
        }

        private void LoadAPIConfig()
        {
            var files = Directory.GetFiles(Environment.CurrentDirectory);
            var initFilePath = Path.Combine(Environment.CurrentDirectory, "Config-Rando.ini");
            if (files.Contains(initFilePath))
            {
                StreamReader init = new StreamReader(initFilePath);
                string api = init.ReadLine().Trim();
                init.Close();
                ApiURL = api;
                _readynessCallback();
            }
            else
            {
                ApiURL = "Enter API URL";
            }
        }
        private void SaveAPIConfig()
        {
            var initFilePath = Path.Combine(Environment.CurrentDirectory, "Config-Rando.ini");
            StreamWriter sw = new StreamWriter(initFilePath, false, Encoding.ASCII);
            sw.WriteLine(ApiURL);
            sw.Close();
            _readynessCallback();
        }
      
    }
}
