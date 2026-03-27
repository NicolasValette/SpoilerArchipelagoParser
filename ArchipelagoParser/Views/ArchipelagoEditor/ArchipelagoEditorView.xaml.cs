using System.Windows.Controls;

namespace NoNiDev.ArchipelagoParser.Views.ArchipelagoEditor
{
    /// <summary>
    /// Logique d'interaction pour ArchipelagoEditorView.xaml
    /// </summary>
    public partial class ArchipelagoEditorView : UserControl
    {
        public ArchipelagoEditorView()
        {
            InitializeComponent();
            DataContext = new ViewModel.ArchipelagoEditorViewModel();
        }
    }
}
