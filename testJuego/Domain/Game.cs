using Newtonsoft.Json.Linq;

namespace testJuego.Domain
{
    public class Game
    {
        public Response LogicGame(Player player, int valueDice)
        {
            Response response = new Response()
            {
                DiceValue = valueDice,
                Message = "Continue playing",
                player = player
            };

            // Llama al metodo Move del panel.
            var nuevaPosicion = new Panel().Move(player, valueDice);

            // Logica de si gana o no.
            // Si llega a posicion 100 gana, si se pasa se queda en la posicion origen.
            if (nuevaPosicion == 100)
            {
                player.CurrentPosition = nuevaPosicion;
                response.Status = 1;
                response.Message = "YOU WIN!";
            }
            else if (nuevaPosicion > 100)
            {
                // El jugador se queda en la misma posicion que estaba antes de lanzar.
            }
            else
            {
                player.CurrentPosition = nuevaPosicion;
            }


            return response;
        }
    }
}
