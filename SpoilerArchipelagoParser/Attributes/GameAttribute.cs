

namespace NoNiDev.SpoilerArchipelagoParser.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class GameAttribute(string gameName) : Attribute
    {
        public string GameName { get; } = gameName;
    }
}
