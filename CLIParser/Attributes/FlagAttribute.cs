
namespace NoNiDev.CLIParser.Attributes
{

    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class FlagAttribute : Attribute
    {
        public string ShortFlag { get; }
        public string LongFlag { get; }
        public string Description { get; }

        public FlagAttribute(string shortFlag, string longFLag="", string description="Missing description")
        {
            ShortFlag = shortFlag;
            LongFlag = longFLag;
            Description = description;
        }
    }
}
