using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolunarFishing
{
    public class LongitudeLatitudeFromZipCodeModel
    {
        public float Lat { get; set; }
        public float Lng { get; set; }
        public Timezone timezone { get; set; }
        
    }

    public class Timezone
    {
        public int utc_offset_sec { get; set; }
        
    }

    
}
