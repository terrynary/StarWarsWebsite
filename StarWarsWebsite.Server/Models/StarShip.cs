
using Newtonsoft.Json;
using StarWarsApiCSharp;
using System.ComponentModel.DataAnnotations;

namespace StarWarsWebsite.Server.Models
{
    public class StarShip : BaseEntity
    {
        private const string PathToEntity = "starships/";
        public int Id { get; set; }
        [JsonProperty]
        public string? Name { get; set; }

        public string? Model { get; set; }

        [JsonProperty(PropertyName = "starship_class")]
        public string? Starship_Class { get; set; }

        public string? Manufacturer { get; set; }

        [JsonProperty(PropertyName = "cost_in_credits")]
        public string? Cost_In_Credits { get; set; }

        [JsonProperty]
        public string? Length { get; set; }

        [JsonProperty]
        public string? Crew { get; set; }

        [JsonProperty]
        public string? Passengers { get; set; }

        [JsonProperty(PropertyName = "max_atmosphering_speed")]
        public string? Max_Atmosphering_Speed { get; set; }

        [JsonProperty(PropertyName = "hyperdrive_rating")]
        public string? Hyperdrive_Rating { get; set; }

        [JsonProperty(PropertyName = "MGLT")]
        public string? MGLT { get; set; }

        [JsonProperty(PropertyName = "cargo_capacity")]
        public string? Cargo_Capacity { get; set; }

        [JsonProperty]
        public string? Consumables { get; set; }

        [JsonProperty]
        public List<string>? Films { get; set; }

        [JsonProperty]
        public List<string>? Pilots { get; set; }
        public string? ImgUrl { get; set; }

        protected override string EntryPath => "starships/";

    }
}
