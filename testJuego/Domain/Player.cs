using System.Text.Json.Serialization;

namespace testJuego.Domain
{
    public class Player
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CurrentPosition { get; set; }

        [JsonIgnore]
        public int FuturePosition { get; set; }
    }
}
