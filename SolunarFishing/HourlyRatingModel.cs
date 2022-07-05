using System.Text.Json.Serialization;

namespace SolunarFishing
{
    public class HourlyRatingModel
    {
        [JsonPropertyName("0")]
        public int MidNightHour { get; set; }
        [JsonPropertyName("1")]
        public int OneAMHour { get; set; }
        [JsonPropertyName("2")]
        public int TwoAMHour { get; set; }
        [JsonPropertyName("3")]
        public int ThreeAMHour { get; set; }
        [JsonPropertyName("4")]
        public int FourAMHour { get; set; }
        [JsonPropertyName("5")]
        public int FiveAMHour { get; set; }
        [JsonPropertyName("6")]
        public int SixAMHour { get; set; }
        [JsonPropertyName("7")]
        public int SevenAMHour { get; set; }
        [JsonPropertyName("8")]
        public int EightAMHour { get; set; }
        [JsonPropertyName("9")]
        public int NineAMHour { get; set; }
        [JsonPropertyName("10")]
        public int TenAMHour { get; set; }
        [JsonPropertyName("11")]
        public int ElevenAMHour { get; set; }
        [JsonPropertyName("12")]
        public int NoonHour { get; set; }
        [JsonPropertyName("13")]
        public int OnePMHour { get; set; }
        [JsonPropertyName("14")]
        public int TwoPMHour { get; set; }
        [JsonPropertyName("15")]
        public int ThreePMHour { get; set; }
        [JsonPropertyName("16")]
        public int FourPMHour { get; set; }
        [JsonPropertyName("17")]
        public int FivePMHour { get; set; }
        [JsonPropertyName("_18")]
        public int SixPMHour { get; set; }
        [JsonPropertyName("19")]
        public int SevenPMHour { get; set; }
        [JsonPropertyName("20")]
        public int EightPMHour { get; set; }
        [JsonPropertyName("21")]
        public int NinePMHour { get; set; }
        [JsonPropertyName("22")]
        public int TenPMHour { get; set; }
        [JsonPropertyName("23")]
        public int ElevenPMHour { get; set; }
    }
}
