using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace NoNiDev.ArchipelagoParser.ViewModel
{
    class PopUpViewModel
    {
        public string Message { get; set; }
        public RelayCommand ButtonCloseComand { get; }

        public PopUpViewModel(string Message) 
        {
            ButtonCloseComand = new RelayCommand( o => Close());
        }
        public void Close()
        {
            this.Close();
        }
    }
}
