using MediatR;
using System;
using System.Numerics;
using testJuego.Application.Commands;
using testJuego.Domain;
using Xunit.Abstractions;

namespace UnitTestJuego
{
    public class UnitTest1
    {
        private readonly ITestOutputHelper output;
 

        public UnitTest1(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void Move()
        {
            // Creo jugador
            var player = new Player()
            {
                Name = "Ana",
                CurrentPosition = 4,
                FuturePosition = 0
            };

            int dadoValue = 1;

            // Panel
            Panel p = new Panel();
            var posicionFinal = p.Move(player, dadoValue);

            Assert.Equal(98, posicionFinal);
        }

        [Fact]
        public void Game()
        {
            // Creo jugador
            var player = new Player()
            {
                Name = "Ana",
                CurrentPosition = 95,
                FuturePosition = 0
            };

            Game g = new Game();
            var response = g.LogicGame(player, 3);

            Assert.Equal(98, player.CurrentPosition);

            response = g.LogicGame(player, 5);
            Assert.Equal(98, player.CurrentPosition);

            response = g.LogicGame(player, 2);
            Assert.Equal(100, player.CurrentPosition);

            Assert.Equal(1, response.Status);
        }

        [Fact]
        public void Partida()
        {
            PlayCommandHandler handler = new PlayCommandHandler();
            Response response = null;

            // Creo jugador
            var player1 = new Player()
            {
                Name = "Ana",
            };

            var player2 = new Player()
            {
                Name = "Paco",
            };

            int index = 1;
            do
            {
                // Par
                if ((index % 2) == 0)
                {
                    PlayCommand command = new PlayCommand()
                    {
                        player = player1
                    };

                    response = handler.Handle(command, new CancellationToken()).Result;
                }
                else
                {
                    PlayCommand command = new PlayCommand()
                    {
                        player = player2
                    };

                    response = handler.Handle(command, new CancellationToken()).Result;
                }

                index++;

            } while (response.Status == 0);
            
            

            this.output.WriteLine("El ganador es: " + response.player.Name);
        }
    }
}