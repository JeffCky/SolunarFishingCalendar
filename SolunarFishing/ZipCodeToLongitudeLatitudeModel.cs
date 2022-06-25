﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace SolunarFishing
{
    public class ZipCodeToLongitudeLatitudeModel 
    {
        public string geopoint { get; set; }
        public string Daylight_savings_time_flag { get; set; }
        public string Timezone { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }

       

        
    }

    

    
}
