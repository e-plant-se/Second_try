using Newtonsoft.Json;

namespace ProjectEPlant.Models
{
    public class RegisterPlantModel
    {
        [JsonProperty("imagen")]
        public string Imagen { get; set; }

        [JsonProperty("nombreComun")]
        public string NombreComun { get; set; }

        [JsonProperty("nombreCientifico")]
        public string NombreCientifico { get; set; }

        [JsonProperty("temporada")]
        public string Temporada { get; set; }

        [JsonProperty("tipoRiego")]
        public string TipoRiego { get; set; }

        [JsonProperty("tipoCultivo")]
        public string TipoCultivo { get; set; }

        [JsonProperty("cicloVida")]
        public string CicloVida { get; set; }

        [JsonProperty("uso")]
        public string Uso { get; set; }

        [JsonProperty("tamaño")]
        public string Tamaño { get; set; }
    }
}
