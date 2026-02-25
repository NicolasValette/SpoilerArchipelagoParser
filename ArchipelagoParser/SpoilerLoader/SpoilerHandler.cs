using NoNiDev.ArchipelagoParser.ViewModel.CustomUserControl;
using NoNiDev.SpoilerArchipelagoParser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NoNiDev.ArchipelagoParser.SpoilerLoader
{
    static class SpoilerHandler
    {
        public static ArchipelagoOption? ArchiOption { get; set; }
        public static event Action? OnSpoilerLoaded;
         
        static SpoilerHandler()
        {
            ArchiOption = null;

            OpenFileViewModel.OnFileOpened += ReadSpoiler;
        }

        public static void ReadSpoiler(string path)
        {
            StreamReader sr = new StreamReader(path);
            SpoilerArchipelagoReader spoilerReader = new();
            ArchiOption = spoilerReader.ReadSpoiler(sr);
            sr.Close();

            OnSpoilerLoaded?.Invoke();
        }
    }
}
