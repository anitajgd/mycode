using MediatR;
using testJuego.Domain;
using testJuego.Domain.Interfaces;

namespace testJuego.Application.Queries
{
    public class GetValueDice : IRequest<int>
    {
        public Dice _dice { get; set; }

        public GetValueDice()
        {
            this._dice = new Dice();
        }
    }

    public class GetValueDiceHandler : IRequestHandler<GetValueDice, int>
    {
        public GetValueDiceHandler()
        {
        }

        public async Task<int> Handle(GetValueDice query, CancellationToken cancellationToken)
        {
            // Lanzamos dado y devolvemos valor.
            int value = query._dice.GetValue();

            return value;
        }
    }
}


