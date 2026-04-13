using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NoNiDev.ArchipelagoParser.App.API
{
    public static class APIConfigService
    {
        private const string INIT_FILE_NAME_RANDO = "Config-Rando.ini";
        private const string INIT_FILE_NAME_SOHAR = "Config-Sohar.ini";

        public static string RandoStatApiURL { get; private set; } = "Enter API URL";
        public static string SOHARApiURL { get; private set; } = "Enter API URL";

        static APIConfigService()
        {
            RandoStatApiURL = LoadAPIConfig(INIT_FILE_NAME_RANDO);
            SOHARApiURL = LoadAPIConfig(INIT_FILE_NAME_SOHAR);
        }

        private static string LoadAPIConfig(string initFileName)
        {
            string apiURL = string.Empty;
            var files = Directory.GetFiles(Environment.CurrentDirectory);
            var initFilePath = Path.Combine(Environment.CurrentDirectory, initFileName);
            if (files.Contains(initFilePath))
            {
                StreamReader init = new StreamReader(initFilePath);
                string api = init.ReadLine()?.Trim() ?? "";
                init.Close();
                apiURL = api;
            }
            else
            {
                apiURL = "Enter API URL";
            }
            return apiURL;
        }
        public static void UpdateRandoStatApiURL(string apiURL)
        {
            RandoStatApiURL = apiURL;
            SaveAPIConfig(INIT_FILE_NAME_RANDO, RandoStatApiURL);
        }
        public static void UpdateSOHARApiURL(string apiURL)
        {
            SOHARApiURL = apiURL;
            SaveAPIConfig(INIT_FILE_NAME_SOHAR, SOHARApiURL);
        }
        public static void SaveConfigFiles()
        {
            SaveAPIConfig(INIT_FILE_NAME_RANDO, RandoStatApiURL);
            SaveAPIConfig(INIT_FILE_NAME_SOHAR, SOHARApiURL);
        }
        private static void SaveAPIConfig(string initFileName, string apiURL)
        {
            var initFilePath = Path.Combine(Environment.CurrentDirectory, initFileName);
            StreamWriter sw = new StreamWriter(initFilePath, false, Encoding.ASCII);
            sw.WriteLine(apiURL);
            sw.Close();
        }
    }
}
