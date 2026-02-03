using NoNiDev.ArchipelagoParser.ViewModel.CustomUserControl;
using System.Windows.Controls;

namespace NoNiDev.ArchipelagoParser.Views.CustomUserControl
{
    /// <summary>
    /// Interaction logic for OpenFileButton.xaml
    /// </summary>
    public partial class OpenFileButton : UserControl
    {
        public OpenFileButton()
        {
            InitializeComponent();
            DataContext = new OpenFileViewModel();
        }
    }
}
