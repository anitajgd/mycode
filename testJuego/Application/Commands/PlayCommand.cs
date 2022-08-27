using MediatR;
using System.Numerics;
using testJuego.Domain;
using testJuego.Domain.Interfaces;

namespace testJuego.Application.Commands
{
    public class PlayCommand : IRequest<Response>
    {
        public Player player { get; set; }
    }

    public class PlayCommandHandler : IRequestHandler<PlayCommand, Response>
    {
        public Task<Response> Handle(PlayCommand request, CancellationToken cancellationToken)
        {
            Response response = new Response();

            // Escucha el evento del dado. No lo implementamos asi que lo pasamos por parametro.
            int diceValue = new Dice().GetValue();

            // Logica juego
            Game g = new Game();
            response = g.LogicGame(request.player, diceValue);


            return Task.FromResult<Response>(response);
        }
    }
}
