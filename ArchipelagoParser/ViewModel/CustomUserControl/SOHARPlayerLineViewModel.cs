using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.ArchipelagoParser.ViewModel.CustomUserControl
{
    public enum SoharPlayer
    {
        None,
        Nono,
        Niko
    }

    public class SOHARPlayerLineViewModel : NotifyableViewModel
    {
        public SoharPlayer? PlayerToSend 
        {   get;
            set
            {
                 field = value;
                NotifyPropertyChanged();
            }
        } = SoharPlayer.None;
        public bool IsChecked
        {
            get => field;
            set
            {
                field = value;

                NotifyPropertyChanged();
            }
        }
        public Array PlayerNames => Enum.GetValues(typeof(SoharPlayer));
        public string PlayerName {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }

        }
        public SOHARPlayerLineViewModel(string name)
        {
            PlayerName = name;
            if (PlayerName.Contains("Nono", StringComparison.InvariantCultureIgnoreCase))
            {
                PlayerToSend = SoharPlayer.Nono;
            }
            else if (PlayerName.Contains("Niko", StringComparison.InvariantCultureIgnoreCase))
            {
                PlayerToSend = SoharPlayer.Niko;
            }
            else
            {
                PlayerToSend = null;
            }
        }
    }
}
