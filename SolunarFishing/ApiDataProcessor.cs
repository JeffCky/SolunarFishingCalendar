using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
                    T longLat = await response.Content.ReadAsAsync<T>();
                    
                    return longLat;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }

        private static readonly List<T> _data = new(); 

        public static void Add(T data)
        {
            _data.Add(data);
        }
    }
}
