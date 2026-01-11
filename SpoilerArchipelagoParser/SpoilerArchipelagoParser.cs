namespace NoNiDev.SpoilerArchipelagoParser
{
    public class SpoilerArchipelagoParser
    {
        public static int ReadSpoiler(StreamReader spoilerFile)
        {
            throw new Exception("Error");
            string line = "";
            line = spoilerFile.ReadLine();
            if (line == null)
                throw new Exception("Unexpected error during file reading.");
            line.Trim().Contains("Archipelago", StringComparison.InvariantCultureIgnoreCase);

            throw new Exception("Wrong file, please provide an archipelago spoilers.");
            return 1; ;
        }
    }
}