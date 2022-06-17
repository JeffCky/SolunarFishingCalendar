using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SolunarFishing
{
    public static class LongitudeLatitudeProcessor
    {
        public static async Task<LongitudeLatitudeFromZipCodeModel> LoadLongitudeLatitude(string zipCode = "")
        {
            string url = "https://www.zipcodeapi.com/rest/vA74qRCnakSGxJjOWfz8Rjarf9P429dXeWf0s137ye7dMdlvg7QOK7K62hSPLMVs/info.json/40047/degrees";

            using (HttpResponseMessage response = await ApiConnector.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    LongitudeLatitudeFromZipCodeModel longLat = await response.Content.ReadAsAsync<LongitudeLatitudeFromZipCodeModel>();
                    
                    return longLat;
                }
                else
                {
                    throw new Exception("not working");
                }
            }
        }
    }
}
