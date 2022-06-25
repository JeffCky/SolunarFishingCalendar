using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SolunarFishing
{
    public static class ApiDataProcessor<T>
    {
        public static async Task<T> LoadApiData(string url = "")
        {
            

            using (HttpResponseMessage response = await ApiConnector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    T result = await response.Content.ReadAsAsync<T>();
                    
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
