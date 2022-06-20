namespace SolunarFishing
{
    public class ZipCodeToLongitudeLatitudeModel
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
