using NoNiDev.CallAPI.RandoStat;
using NoNiDev.SpoilerArchipelagoParser.Options;
using NoNiDev.SpoilerArchipelagoParser.Options.OWOptions;
using NoNiDev.SpoilerArchipelagoParser.Options.SOHOptions;
using NoNiDev.SpoilerArchipelagoParser.RandoStats;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace NoNiDev.CallAPI.AllRandomGame
{
    public static class APIToRandomGames
    {
        private static string _baseURL = "";
        public static void InitURL(string baseURL)
        {
            _baseURL = baseURL;
        }
        public static async Task<string> AddRandomGames(GameOptions option)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string jsonString = string.Empty;
            if (option is SOHOption optsoh)
                jsonString = JsonSerializer.Serialize<SOHOption>(optsoh, options);
            else if (option is OWOption optow)
                jsonString = JsonSerializer.Serialize<OWOption>(optow, options);
            using var client = new HttpClient();
            using var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_baseURL, content);
            var responseText = await response.Content.ReadAsStringAsync();
            return responseText;
        }
    }
}
