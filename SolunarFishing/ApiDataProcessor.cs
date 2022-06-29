using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace SolunarFishing
{
    public static class ApiDataProcessor
    {
        public static async Task<string> LoadApiData(string url = "")
        {
            

            using (HttpResponseMessage response = await ApiConnector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        
    }
}
