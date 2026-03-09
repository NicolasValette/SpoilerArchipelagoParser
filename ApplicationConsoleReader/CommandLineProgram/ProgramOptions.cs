using NoNiDev.CLIParser.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;


namespace NoNiDev.ApplicationConsoleReader.CommandLineProgram
{
    // spoilerpeligo.exe [-a] [-g["Ship of Harkinien|Outer Wilds|All"]] [-c "path\config.ini"] "path\spoiler.txt"
    public class ProgramOptions
    {
        [Flag("c", "config", "The config File.")]
        public string ConfigFile { get; set; } = string.Empty;

        [Flag("a", "addarchipel", "Flag if we add archipel or not")]
        public bool AddArchipel { get; set; }
        [Flag("g", "game", "Game list")]
        public List<string> Games { get; set; } = new List<string>();

    }
}
