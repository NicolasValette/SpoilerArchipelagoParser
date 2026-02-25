using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace NoNiDev.ArchipelagoParser.Views.SpoilerView
{
    /// <summary>
    /// Logique d'interaction pour SpoilerView.xaml
    /// </summary>
    public partial class SpoilerView : UserControl
    {
        public SpoilerView()
        {
            InitializeComponent();
            DataContext = new ViewModel.SpoilerViewModel();
        }
    }
}
