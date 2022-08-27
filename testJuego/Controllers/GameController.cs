using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using testJuego.Application.Commands;
using testJuego.Application.Queries;
using testJuego.Domain;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testJuego.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IMediator mediator;

        public GameController(IMediator mediator)
        {
            this.mediator = mediator;
        }


        [HttpGet("dice")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<int>> Get()
        {
            return await this.mediator.Send(new GetValueDice());
        }

        [HttpPost("play")]
        public async Task<ActionResult> Play([FromBody] Player request)
        {
            PlayCommand command = new PlayCommand()
            {
               player = request
            };

            var rs = await this.mediator.Send(command);

            return this.Ok(rs);
        }

        [HttpPost("player")]
        [ProducesResponseType(typeof(Response), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.UnprocessableEntity)]
        public async Task<ActionResult> Post([FromBody] Player request)
        {
            CreatePlayerCommand command = new CreatePlayerCommand()
            {
                player = request
            };

            var rs = await this.mediator.Send(command);

            return this.Ok(rs);
        }
    }
}
