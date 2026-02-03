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
        public void ReadSpoilerTest()
        {

            var stream = new StreamReader("E:\\Dev\\git\\Source\\Repos\\SpoilerArchipelagoParser\\SOHParserTest\\Ressource\\SpoilerExemple.txt");
            SpoilerArchipelagoReader spoilerReader = new();
            try 
            {
                var option = spoilerReader.ReadSpoiler(stream);
                Assert.That(option, Is.Not.Null);
            }
            catch
            {
                Assert.Fail();
            }
            
            

            //Assert.Throws<Exception>(() => SpoilerArchipelagoParser.ReadSpoiler(stream));

           
        }
    }
}
