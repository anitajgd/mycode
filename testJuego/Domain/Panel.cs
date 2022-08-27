using Newtonsoft.Json.Linq;

namespace testJuego.Domain
{
    public class Panel
    {
        private int _square = 100;


        // Menos valor del dado
        public int Square
        {
            get => _square;
            set => _square = value;
        }

        // Establecer las casillas por las que avanzarias con las escaleras.
        private static readonly Dictionary<int, int> Movements = new Dictionary<int, int>
        {
            // Leaders
            { 1, 95 },
            { 2, 96 },
            { 3, 97 },
            { 4, 98 },
            { 5, 99 },

            // Snakes
            //{ 8, 1 }
        };
             

        public int Move(Player player, int diceValue)
        {
            int posicionFinal = player.CurrentPosition;

            // Revisamos la posicion origen del jugador sumando al valor del dado y revisando 
            // las posiciones de las escaleras y snakes y comprobamos si gana o no.
            var posicionProvisional = player.CurrentPosition + diceValue;

            if (Movements.ContainsKey(posicionProvisional))
            {
                foreach (var item in Movements)
                {
                    if (item.Key == posicionProvisional)
                    {
                        posicionFinal = item.Value;
                    }
                }
            }
            else
            {
                posicionFinal = posicionProvisional;
            }
            

            return posicionFinal;
        }
    }
}
