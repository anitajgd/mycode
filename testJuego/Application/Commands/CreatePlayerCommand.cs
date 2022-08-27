using MediatR;
using testJuego.Domain;
using testJuego.Domain.Interfaces;

namespace testJuego.Application.Commands
{
    public class CreatePlayerCommand : IRequest<Response>
    {
        public Player player { get; set; }
    }

    public class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, Response>
    {
        //private readonly IPlayerRepository repository;
        //public CreatePlayerCommandHandler(IPlayerRepository repository)
        //{
        //    this.repository = repository;
        //}

        public Task<Response> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            Response response = new Response();

            // Save en BD
            //this.repository.CreateEntity(request.player);

            // Static response
            response.player = request.player;

            return Task.FromResult<Response>(response);
        }
    }
}
