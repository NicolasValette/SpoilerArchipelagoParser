using NoNiDev.CLIParser.Attributes;
using System;
using System.Collections.Generic;
using System.Reflection;


namespace NoNiDev.ApplicationConsoleReader.CommandLineProgram
{
    // spoilerpeligo.exe [-a] [-g["Ship of Harkinien|Outer Wilds|All"]] [-c "path\config.ini"] "path\spoiler.txt"
    public class ProgramOptions
    {
        #region ADD ARCHIPEL
        [Flag("a", "addarchipel", "Flag if we add archipel or not")]
        public bool AddArchipel { get; set; }
        [Flag("n", "name", "Archipelago name")]
        public string ArchipelagoName { get; set; } = string.Empty;
        [Flag("u", "url", "Archipelago url")]
        public string Url { get; set; } = string.Empty;
        #endregion
        #region ADD RANDOM GAMES
        [Flag("g", "game", "Game list")]
        public List<string> Games { get; set; } = new List<string>();
        #endregion
        #region COMMON
        [Flag("c", "config", "The config File.")]
        public string ConfigFile { get; set; } = string.Empty;
        #endregion

    }
}
