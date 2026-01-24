using System.Windows.Controls;
using NoNiDev.ArchipelagoParser.ViewModel;

namespace NoNiDev.ArchipelagoParser.Views
{
    /// <summary>
    /// Interaction logic for RandoStatsView.xaml
    /// </summary>
    public partial class RandoStatsView : UserControl
    {
        public RandoStatsView()
        {
            InitializeComponent();
            DataContext = new RandoStatsViewModel();
        }
    }
}
