using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEPlant.Models
{
    public class UserDataModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
