using System.IO;
using System.Text;

namespace NoNiDev.ArchipelagoParser.ViewModel.CustomUserControl
{
  
    class RandoStatAPIViewModel : APIViewModel
    {
        private const string INIT_FILE_NAME = "Config-Rando.ini";
        public RandoStatAPIViewModel(APICallType callTYpe, Action callback) : base(INIT_FILE_NAME, callTYpe, callback)
        {
           
        }
      
    }
}
