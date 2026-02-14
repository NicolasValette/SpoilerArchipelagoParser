using NoNiDev.SpoilerArchipelagoParser;
using NoNiDev.SpoilerArchipelagoParser.Options;
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
                SOHOption sohOption = new SOHOption(option.SOHOptions[0].GameOptionsDictionnary);
                sohOption.Process();
                 
                var options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                };
                
                string jsonString = JsonSerializer.Serialize<SOHOption>(sohOption, options);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }
    }
}
