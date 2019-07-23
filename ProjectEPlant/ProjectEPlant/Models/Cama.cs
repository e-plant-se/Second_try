using Newtonsoft.Json;

namespace ProjectEPlant.Models
{
    public class Cama
    {
        public partial class Welcome
        {
            [JsonProperty("")]
            public Item[] Items { get; set; }
        }

        public partial class Item
        {
            [JsonProperty("estructura")]
            public string Estructura { get; set; }

            [JsonProperty("fechaCultio")]
            public string FechaCultio { get; set; }

            [JsonProperty("huerto")]
            public string Huerto { get; set; }

            [JsonProperty("idCama")]
            public string IdCama { get; set; }

            [JsonProperty("planta1")]
            public string Planta1 { get; set; }

            [JsonProperty("tipo")]
            public string Tipo { get; set; }
        }
    }
}