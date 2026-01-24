using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace NoNiDev.CallAPI.RandoStat
{
    public static class APIToRandoStat
    {
        private static string _baseURL = "";
        public static void InitURL (string baseURL)
        {
            _baseURL = baseURL;
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
