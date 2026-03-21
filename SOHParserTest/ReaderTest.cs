using NoNiDev.SpoilerArchipelagoParser;
using NoNiDev.SpoilerArchipelagoParser.Options;
using NoNiDev.SpoilerArchipelagoParser.Options.OWOptions;
using NoNiDev.SpoilerArchipelagoParser.Options.SOHOptions;
using System.Text.Json;

namespace SOHParserTest
{
    public class ReaderTest
    {
        [SetUp]
        public void Setup()
        {

        }
        
        [Test]
        public void AboutTest()
        {
            var stream = new StreamReader("E:\\Dev\\git\\Source\\Repos\\SpoilerArchipelagoParser\\SOHParserTest\\Ressource\\SpoilerExemple.txt");
            SpoilerArchipelagoReader spoilerReader = new();
            string about = spoilerReader.About();
            Assert.That(about, Is.Not.Empty);
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
        [Test]
        public void ReflexionTest()
        {
            var stream = new StreamReader("E:\\Dev\\git\\Source\\Repos\\SpoilerArchipelagoParser\\SOHParserTest\\Ressource\\SpoilerExemple.txt");
            SpoilerArchipelagoReader spoilerReader = new();
            try
            {
                var option = spoilerReader.ReadSpoiler(stream);
                //SOHOption sohOption = new SOHOption(option.SOHOptionsList[0].PlayerName,option.SOHOptionsList[0].GameOptionsDictionnary);
               
                 
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                foreach(GameOptions opt in option.SOHOptionsList)
                {
                    string jsonString = string.Empty;
                    if (opt is SOHOption sohOption)
                        jsonString = JsonSerializer.Serialize<SOHOption>(sohOption, options);
                    else if (opt is OWOption owOption)
                        jsonString = JsonSerializer.Serialize<OWOption>(owOption, options);
                }
                

            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
