



//using Newtonsoft.Json;
using System;
using System.Collections;
using System.IO;
using System.Threading.Tasks;
using static SolunarFishing.UserInterface;
using System.Linq;
using System.Collections.Generic;
using System.Text.Json;

namespace SolunarFishing
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            //ApiConnector.InitializeClient();
            //UserInterface.AskAndRetrieveUserInput();

            //await LoadLongLat();


            //await LoadSolunarData();

            //Environment.Exit(0);
            //await SolunarForecast.Forecast(7);

            List<ZipCodeToLongitudeLatitudeModel> zipsToLongLat = new List<ZipCodeToLongitudeLatitudeModel>();
            string path = Directory.GetCurrentDirectory();
            
            string fileName = Path.GetFullPath(Path.Combine(path, @"..\..\..\Resource\\US_Zips.json"));
            using (StreamReader r = new StreamReader(fileName))
            {
                string json = r.ReadToEnd();
                zipsToLongLat = JsonSerializer.Deserialize<List<ZipCodeToLongitudeLatitudeModel>>(json);
            }

            var result = from course in zipsToLongLat
                         where course.Zip == "40047"
                         select course;
            Console.WriteLine(result.First().City);

            foreach (var item in result)
            {
                Console.WriteLine(item.Latitude);
            }
            
            


            
        }

        private static void LoadLongLat(string zipCode = "40047")
        {
        }

                
            

            
            
        

            
    }



}

    


