

namespace NoNiDev.SpoilerArchipelagoParser.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GameAttribute(string gameName, string version) : Attribute
    {
        public string GameName { get; } = gameName;
        public string ApWorldVersion { get; } = version;
    }
}
