using Newtonsoft.Json.Converters;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace testJuego.Domain
{
    public class Response
    {
        /// <summary>
        /// 0 = Partida continua
        /// 1 = Fin de la partida
        /// </summary>
        public int Status { get; set; } 

        public Player player { get; set; }

        public int DiceValue { get; set; }

        public string Message { get; set; }
    }
}
