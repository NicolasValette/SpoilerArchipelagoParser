using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.ArchipelagoParser.ViewModel.SpoilerViewer
{
    class SpoilerGameItemLineViewModel : NotifyableViewModel
    {
        public string PropertyName
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }

        }
        public string PropertyValue
        {
            get => field;
            set
            {
                field = value;
                NotifyPropertyChanged();
            }

        }
        public SpoilerGameItemLineViewModel(string propertyName, string propertyValue)
        {
            PropertyName = propertyName;
            PropertyValue = propertyValue;
        }

    }
}
