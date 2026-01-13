using NoNiDev.SpoilerArchipelagoParser;

namespace SOHParserTest
{
    public class ReaderTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {

            var stream = new StreamReader("E:\\Dev\\git\\Source\\Repos\\SpoilerArchipelagoParser\\SOHParserTest\\Ressource\\SpoilerExemple.txt");

            


            //Assert.Throws<Exception>(() => SpoilerArchipelagoParser.ReadSpoiler(stream));

           
        }
    }
}
