using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace NoNiDev.CallAPI.RandoStat
{
    public static class APIToRandoStat
    {
        private static string _baseURL = "";
        public static void InitURL(string baseURL)
        {
            _baseURL = baseURL;
        }
        public static async Task<string[]> GetGameNames()
        {
            using var client = new HttpClient();
            var response = await client.GetAsync(_baseURL + "?action=jeux");
            var responseText = await response.Content.ReadAsStringAsync();
            string[]? games = JsonSerializer.Deserialize<string[]>(responseText);
            if (games == null)
                return Array.Empty<string>();
            return games;
        }
        public static async Task<string> AddPlayer(string name)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            RandoStatDataGeneric randoStat = new RandoStatDataGeneric
            {
                Action = RandoStatAction.addJoueur,
                Payload = new PayloadGeneric
                {
                    Name = name
                }
            };
            string jsonString = JsonSerializer.Serialize<RandoStatDataGeneric>(randoStat, options);
            using var client = new HttpClient();
            using var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_baseURL + "?action=ajouterJeux", content);
            var responseText = await response.Content.ReadAsStringAsync();
            return responseText;
        }

        public static async Task<string> AddGame(string gameName)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            RandoStatDataGeneric randoStat = new RandoStatDataGeneric
            {
                Action = RandoStatAction.AddJeu,
                Payload = new PayloadGeneric
                {
                    Name = gameName
                }
            };
            string jsonString = JsonSerializer.Serialize<RandoStatDataGeneric>(randoStat, options);
            using var client = new HttpClient();
            using var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_baseURL + "?action=ajouterJeux", content);
            var responseText = await response.Content.ReadAsStringAsync();
            return responseText;
        }
        public static async Task<string> AddArchipel(RandoStatData randoStat)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            string jsonString = JsonSerializer.Serialize<RandoStatData>(randoStat, options);

            using var client = new HttpClient();
            using var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(_baseURL, content);
            var responseText = await response.Content.ReadAsStringAsync();
            return responseText;
        }


    }
}
