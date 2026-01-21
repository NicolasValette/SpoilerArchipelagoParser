using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace NoNiDev.ArchipelagoParser.ViewModel
{
    public class OpenFileViewModel
    {
        public static event Action <string>? OnFileOpened;
        public RelayCommand ButtonCommand { get; }

        public OpenFileViewModel()
            {
            ButtonCommand = new RelayCommand(o => OpenFileWindow());
        }


        public void OpenFileWindow()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.FileName = "Document"; // Default file name
            dialog.DefaultExt = ".txt"; // Default file extension
            dialog.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dialog.ShowDialog();

            // Process open file dialog box results
            if (result.Value)
            {
                // Open document
                string filename = dialog.FileName;
                OnFileOpened?.Invoke(filename);
            }
        }
    }
}
