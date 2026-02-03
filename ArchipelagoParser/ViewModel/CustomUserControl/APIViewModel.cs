using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NoNiDev.ArchipelagoParser.ViewModel.CustomUserControl
{
    public enum APICallType
    {
        Get,
        Post
    }
    public class APIViewModel : NotifyableViewModel
    {
        protected Action _readynessCallback;
        protected APICallType _callTYpe;
        protected string _initFileName;
        //"Config-Rando.ini"
        public string? ApiURL
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


        public APIViewModel(string initFileName, APICallType callTYpe, Action callback)
        {
            _readynessCallback = callback;
            RequestResponse = "Response will be here";
            _callTYpe = callTYpe;
            _initFileName = initFileName;
            LoadAPIConfig();
        }

        private void LoadAPIConfig()
        {
            var files = Directory.GetFiles(Environment.CurrentDirectory);
            var initFilePath = Path.Combine(Environment.CurrentDirectory, _initFileName);
            if (files.Contains(initFilePath))
            {
                StreamReader init = new StreamReader(initFilePath);
                string api = init.ReadLine()?.Trim() ?? "" ;
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
            var initFilePath = Path.Combine(Environment.CurrentDirectory, _initFileName);
            StreamWriter sw = new StreamWriter(initFilePath, false, Encoding.ASCII);
            sw.WriteLine(ApiURL);
            sw.Close();
            _readynessCallback();
        }
    }
}
