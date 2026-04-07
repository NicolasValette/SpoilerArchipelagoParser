using System;
using System.Collections.Generic;
using System.Text;

namespace NoNiDev.ArchipelagoParser.App
{
    public class AppInfoService
    {
        public static string AssemblyVersion
        {
            get
            {
                var v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string suffix = "";
#if DEBUG
                suffix = " (Debug)";
#endif
                return $"{v.Major}.{v.Minor}.{v.Build}{suffix}";
            }
        }
    }
}
