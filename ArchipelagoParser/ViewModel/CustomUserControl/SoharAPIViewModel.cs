using System.IO;
using System.Text;

namespace NoNiDev.ArchipelagoParser.ViewModel.CustomUserControl
{
    public class SoharAPIViewModel : APIViewModel
    {
        private const string INIT_FILE_NAME = "Config-Sohar.ini";
        public SoharAPIViewModel(APICallType callTYpe, Action callback) : base(INIT_FILE_NAME, callTYpe, callback)
        {
        }

    }
}
